using Contracts.InputModels.ExcelFilter;
using Contracts.Interface.Shared;
using Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.Data.OleDb;
using System.IO;

namespace Service.Service.Shared
{
    public class ExcelService : IExcelService, IBaseService
    {
        private readonly IGenericRepository<string, string> _repo;
        private readonly IHostingEnvironment _hostEnvironment;
        public ExcelService(IGenericRepository<string, string> repo, IHostingEnvironment hostingEnvironment)
        {
            _repo = repo;
            _hostEnvironment = hostingEnvironment;
        }
        public async Task<GSActionResult<object>> Import(string filePath, string destinationName, Guid currentUser)
        {
            var result = new GSActionResult<object>();
            try
            {
                StringWriter swOrder = new StringWriter();
                ConvertExcelToDataTable(filePath).WriteXml(swOrder);

                result.Data = await _repo.Insert("dbo.Gsp_ImportExcel", new { userId = currentUser, destinationName, xmlString = swOrder.ToString() });
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.Data = ex.Message;
                result.Message = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }
        public async Task<DataTable> Export(IBaseExcel excelObj)
        {
            try
            {
                return (await _repo.GetDataTable(excelObj.ProcedureName, excelObj.filterObject));
            }
            catch (Exception ex)
            {
                return new DataTable();
                throw;
            }


        }
        private DataTable ConvertExcelToDataTable(string fileName)
        {
            string contentPath = _hostEnvironment.ContentRootPath;
            string webRootPath = string.Concat(_hostEnvironment.ContentRootPath, ("\\DataFile_Repository\\ImportedFile\\"));
            string path = string.Concat(webRootPath, fileName);
            DataTable dtResult = null;
            int totalSheet = 0; //No of sheets on excel file  
                                // using (OleDbConnection objConn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FileName + ";Extended Properties=Excel 8.0"))
            using (OleDbConnection objConn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1;';"))
            {
                objConn.Open();
                OleDbCommand cmd = new OleDbCommand();
                OleDbDataAdapter oleda = new OleDbDataAdapter();
                DataSet ds = new DataSet();
                DataTable dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string sheetName = string.Empty;
                if (dt != null)
                {
                    var tempDataTable = (from dataRow in dt.AsEnumerable()
                                         where !dataRow["TABLE_NAME"].ToString().Contains("FilterDatabase")
                                         select dataRow).CopyToDataTable();
                    dt = tempDataTable;
                    totalSheet = dt.Rows.Count;
                    sheetName = dt.Rows[0]["TABLE_NAME"].ToString();
                }
                cmd.Connection = objConn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM [" + sheetName + "]";
                oleda = new OleDbDataAdapter(cmd);
                oleda.Fill(ds, "excelData");
                dtResult = ds.Tables["excelData"];
                objConn.Close();
                return dtResult; //Returning Dattable  
            }
        }

    }
}

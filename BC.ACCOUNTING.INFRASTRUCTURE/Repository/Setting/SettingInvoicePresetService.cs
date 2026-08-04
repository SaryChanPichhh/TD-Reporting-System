using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BC.ACCOUNTING.APPLICATION.Interfaces.Setting;
using BC.ACCOUNTING.CORE.Entities;
using BC.ACCOUNTING.INFRASTRUCTURE.DBAccess;

namespace BC.ACCOUNTING.INFRASTRUCTURE.Repository.Setting
{
    public class SettingInvoicePresetService(ISqlDataAccess sqlDataAccess) : ISettingInvoicePresetRepository
    {

        public async Task<SettingInvoicePresetModel> GetSettingInvoicePresentAsync(string dbCode, string connection)
        {
            var sql = $@"SELECT TIS.DB_CODE DbCode
                      ,CAST (CASE WHEN TIS.SHOW_NAME = 1 THEN 1 ELSE 0 END AS BIT) ShowShopName
                      ,CAST (CASE WHEN TIS.SHOW_VAT = 1 THEN 1 ELSE 0 END AS BIT)  ShowVat
                      ,CAST (CASE WHEN TIS.SHOW_RECEIVE = 1 THEN 1 ELSE 0 END AS BIT) ShowReceive
                      ,TIS.DESCRIPTION Note
                      ,CAST(CASE WHEN TIS.SHOW_REMAIN = 1 THEN 1 ELSE 0 END AS BIT) ShowRemain
                      ,CAST(CASE WHEN TIS.SHOW_NOTE = 1 THEN 1 ELSE 0 END AS BIT) ShowNote
                      , CAST(CASE WHEN TIS.SHOW_CUST_TEL = 1 THEN 1 ELSE 0 END AS BIT) ShowCustTel
                      ,CAST(CASE WHEN TIS.SHOW_CUST_LOC = 1 THEN 1 ELSE 0 END AS BIT) ShowCustAddress
                      ,TIS.LOGO_BOX_SHAPE LogoShape
                      ,CAST(CASE WHEN TIS.SHOW_IMG = 1 THEN 1 ELSE 0 END AS BIT) ShowImage
                      ,TIS.SPACING Spacing
                      ,TIS.FONT_SIZE FontSize
                      ,CAST(CASE WHEN TIS.SHOW_DISCOUNT = 1 THEN 1 ELSE 0 END AS BIT) ShowDiscount
                      ,TIS.NUMBER_DIGITS NumberDigit
                      , CAST(CASE WHEN TIS.SHOW_IMG_QR = 1 THEN 1 ELSE 0 END AS BIT) ShowImageQr
                      ,CAST(CASE WHEN TIS.SHOW_IMG_QR_LAB = 1 THEN 1 ELSE 0 END AS BIT) ShowImageQrFrontScreen FROM TD_INVOICE_SETTING TIS
                WHERE TIS.DB_CODE = @DB_CODE";
            var execute = await sqlDataAccess.LoadSingleData<SettingInvoicePresetModel,dynamic>(sql,new{DB_CODE = dbCode},connectionString:connection);
            return execute;
        }
    }
}

using BC.ACCOUNTING.CORE.DTO.General;
using BC.ACCOUNTING.REPORT.DTO;
using BC.ACCOUNTING.REPORT.Models;
using DevExpress.XtraReports.UI;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using BC.ACCOUNTING.REPORT.DataSources.MB;
using BC.ACCOUNTING.REPORT.DTO.MB;
using BC.ACCOUNTING.REPORT.DTO.RESTAURANT;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace BC.ACCOUNTING.REPORT.Helper
{
    public static class ReportExtension
    {
       
        public static List<FlatPurchaseOrderRow> Flatten(PurchaseOrderDto po)
        {
            var result = new List<FlatPurchaseOrderRow>();
            int rowNumber = 1;

            foreach (var item in po.Items)
            {
                bool isFirst = true;
                foreach (var uc in item.UnitConvert)
                {
                    result.Add(new FlatPurchaseOrderRow
                    {
                        RowNumber = isFirst ? rowNumber++.ToString() : string.Empty,  // Only show row number on first line
                        ItemCode = isFirst ? item.ItemCode : string.Empty,
                        ItemDesc = isFirst ? item.ItemDesc : string.Empty,
                        Qty = uc.Qty,
                        UnitStock = uc.UnitStock,
                        Price = uc.Price,
                        Total = uc.Total,

                    });

                    isFirst = false;
                }
            }

            return result;
        }

        public static List<FlatInvoiceRow> Flatten(SaleInvoiceDto po)
        {
            var result = new List<FlatInvoiceRow>();
            int rowNumber = 1;

            foreach (var item in po.Items)
            {
                bool isFirst = true;
                foreach (var uc in item.UnitConvert)
                {
                    result.Add(new FlatInvoiceRow
                    {
                        RowNumber = isFirst ? rowNumber++.ToString() : string.Empty,  // Only show row number on first line
                        ItemCode = isFirst ? item.ItemCode : string.Empty,
                        ItemDesc = isFirst ? item.ItemDesc : string.Empty,
                        Qty = uc.Qty,
                        Discount = item.Discount,
                        DiscountPercent = item.DiscountPercent,
                        UnitStock = uc.UnitStock,
                        Price = uc.Price,
                        Total = uc.Total
                    });

                    isFirst = false;
                }
            }

            return result;
        }

        
        public static OtpEntry GenerateSecureOtp()
        {
            byte[] bytes = new byte[4];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(bytes);
            }

            int otp = Math.Abs(BitConverter.ToInt32(bytes, 0) % 900000 + 100000);

            return new OtpEntry
            {
                OtpCode = otp.ToString("D6"),
                CreatedAt = DateTime.UtcNow
            };
        }
        public static void SetCellColorBasedOnValue(XRTableCell? cell)
        {
            if (cell == null) return;

            string rawText = cell.Text.Replace("$", "").Replace(",", "").Trim();
            if (rawText.StartsWith("(") && rawText.EndsWith(")"))
            {
                rawText = "-" + rawText.Trim('(', ')');
            }
            if (double.TryParse(rawText, out double value))
            {
                if (value > 0)
                    cell.ForeColor = Color.Green;
                else if (value < 0)
                    cell.ForeColor = Color.Red;
                else
                    cell.ForeColor = Color.Black;
            }
            else
            {
                cell.ForeColor = Color.Black;
            }
        }

        #region JWTToken

        public static string GenerateJwtToken(ClaimDTO request, AppSettings appSettings)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, appSettings.Subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("UserId", request.UserId.ToString()),
                new Claim("Username", request.Username!),
                new Claim("DbCode", request.DbCode!),
                new Claim("AppCode", request.AppCode!),
                new Claim("CompanyCode", request.CompanyCode!),
                new Claim("CurrentDate", request.CurrectDate.ToString("MM/dd/yyyy")),
                new Claim("InvoiceEntryCode", request.InvoiceEntryCode!),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.Key));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new JwtSecurityToken(
                appSettings.Issuer,
                appSettings.Audience,
                claims,
                expires: DateTime.UtcNow.AddDays(1000),
                signingCredentials: signIn
                );
            var token = tokenHandler.WriteToken(tokenDescriptor);
            return (token);
        }

        public static ClaimDTO DecodeJwt(ClaimsPrincipal user)
        {
            if (user?.Identity?.IsAuthenticated != true || !user.Claims.Any())
                throw new ArgumentException("ClaimsPrincipal does not contain valid claims.");

            return new ClaimDTO
            {
                UserId = int.TryParse(user.FindFirst("UserId")?.Value, out var userId) ? userId : 0,
                Username = user.FindFirst("Username")?.Value ?? string.Empty,
                DbCode = user.FindFirst("DbCode")?.Value ?? string.Empty,
                AppCode = user.FindFirst("AppCode")?.Value ?? string.Empty,
                CompanyCode = user.FindFirst("CompanyCode")?.Value ?? string.Empty,
                CurrectDate = DateTime.TryParse(user.FindFirst("CurrentDate")?.Value, out var currentDate)
                    ? currentDate
                    : DateTime.Now,
                InvoiceEntryCode = user.FindFirst("InvoiceEntryCode")?.Value ?? string.Empty,
                Period = user.FindFirst("Period")?.Value ?? string.Empty
            };
        }

        #endregion


        public static CreditNoteFlattenDto CreditNoteFlatten(this CreditNoteDto dto)
        {
            var data = new List<CreditNoteFlattenDataSource>();
            foreach (var item in dto.Items)
            {
                var isDuplicate = false;
                foreach (var unit in item.UnitConvert)
                {
                    
                    data.Add(new CreditNoteFlattenDataSource
                    {
                        ItemCode = isDuplicate ? string.Empty : item.ItemCode,
                        ItemDesc = isDuplicate ? string.Empty : item.ItemDesc,
                        Qty = unit.Qty,
                        UnitStock = unit.UnitStock,
                        Price = unit.Price,
                        Total = unit.Total
                    });
                    isDuplicate = true;
                }
            }
            Debug.WriteLine(data);
            return new CreditNoteFlattenDto
            {
                Items = data,
                Address = dto.Address,
                CreditTransRef = dto.CreditTransRef,
                CustomerName = dto.CustomerName,
                Date = dto.Date,
                Note = dto.Note,
                SaleRep = dto.SaleRep,
                TransRef = dto.TransRef,ExchangeRate = dto.ExchangeRate,
                TotalRiel = dto.TotalRiel,
                TotalDollar = dto.TotalDollar
            };
        }
    }
}

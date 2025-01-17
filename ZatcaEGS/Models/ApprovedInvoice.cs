﻿using System.ComponentModel.DataAnnotations;
using ZatcaEGS.Helpers;
using Zatca.eInvoice.Helpers;

namespace ZatcaEGS.Models
{
    public class ApprovedInvoice
    {
        [Key]
        public string ZatcaUUID { get; set; }
        public string ManagerUUID { get; set; }
        public string InvoiceType { get; set; }
        public string InvoiceSubType { get; set; }
        public string Reference { get; set; }
        public string IssueDate { get; set; }
        public string PartyName { get; set; }
        public string CurrencyCode { get; set; } = "SAR";

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal Amount { get; set; } = 0;
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal TaxAmount { get; set; } = 0;
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal TotalAmount { get; set; } = 0;
        public string RequestType { get; set; }
        public string StatusCode { get; set; }
        public string ApprovalStatus { get; set; }
        public string CertificateInfo { get; set; }
        public int ICV { get; set; }
        public string InvoiceHash { get; set; }
        public string EditData { get; set; } //Manager Data
        public string Referrer { get; set; } //Manager Data
        public string CallBack { get; set; } //Manager Data
        public string ServerResult { get; set; }
        public string Base64SignedInvoice { get; set; }
        public string Base64QrCode { get; set; }
        public string XmlFileName { get; set; }
        public EnvironmentType EnvironmentType { get; set; } = EnvironmentType.NonProduction;
        public DateTime Timestamp { get; set; } = DateTime.Now;

        private string _decodedQrCode = "Uncleared Invoice";
        public string DecodedQrCode
        {
            get
            {
                if (!string.IsNullOrEmpty(Base64QrCode)) { _decodedQrCode = QrCodeDecoder.GetDecodedContentAsString(Base64QrCode); }
                return _decodedQrCode;
            }
        }
    }
}

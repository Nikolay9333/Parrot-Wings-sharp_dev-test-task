using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace ParrotWings.Entities
{
    /// <summary>
    /// Денежный перевод на сайте ПМ
    /// </summary>
    public class MoneyTransfer
    {
        /// <summary>
        /// ID транзакции денежного перевода
        /// </summary>
        [Key]
        [JsonProperty("id")]
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// Сумма денежного перевода
        /// </summary>
        [Required]
        [JsonProperty("amount")]
        [Column("amount")]
        public long Amount { get; set; }

        /// <summary>
        /// почта отправителя 
        /// </summary>
        [JsonProperty("senderEmail")]
        [Column("sender_email")]
        public string SenderEmail { get; set; }

        /// <summary>
        /// Почта получателя
        /// </summary>
        [JsonProperty("recipientEmail")]
        [Column("recipient_email")]
        public string RecipientEmail { get; set; }

        /// <summary>
        /// Дата подтверждения транзакции
        /// </summary>
        ///  [JsonProperty("created_at")]
        [JsonProperty("commitAt")]
        [Column("commit_at")]
        public DateTime? CommitAt { get; set; }
    }
}
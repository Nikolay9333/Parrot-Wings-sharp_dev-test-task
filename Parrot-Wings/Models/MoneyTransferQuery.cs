using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Parrot_Wings.Models
{
    /// <summary>
    /// Запрос на выполнение денежного перевода
    /// </summary>
    public class MoneyTransferQuery
    {
        /// <summary>
        /// Сумма денежного перевода
        /// </summary>
        [Required]
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// почта отправителя (FK)
        /// </summary>
        [JsonProperty("senderEmail")]
        public string SenderEmail { get; set; }

        /// <summary>
        /// Почта получателя (FK)
        /// </summary>
        [JsonProperty("recipientEmail")]
        [Column("recipient_email")]
        public string RecipientEmail { get; set; }
    }
}
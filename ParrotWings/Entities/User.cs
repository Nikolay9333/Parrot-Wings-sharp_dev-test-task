using System.ComponentModel.DataAnnotations;

namespace ParrotWings.Entities
{
    /// <summary>
    /// Пользователь сайта PW
    /// </summary>
    public class User
    {
        #region Properties

        /// <summary>
        /// Электронная почта пользователя
        /// </summary>
        [StringLength(254)]
        [Key]
        public string Email { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        [StringLength(40)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        [StringLength(50)]
        [Required]
        public string SurName { get; set; }

        /// <summary>
        /// Пароль пользователя от учетной записи
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Текщийй баланс пользователя
        /// </summary>
        [Required]
        public decimal Balance { get; set; }

        #endregion
    }
}
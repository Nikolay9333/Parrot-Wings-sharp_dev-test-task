using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ParrotWings.Entities
{
    /// <summary>
    /// Пользователь сайта PW
    /// </summary>
    public class User : IdentityUser
    {
        #region Properties

        /// <summary>
        /// Текущий баланс пользователя
        /// </summary>
        [Required]
        public decimal Balance { get; set; }

        #endregion

        #region DelMe

        ///// <summary>
        ///// Электронная почта пользователя
        ///// </summary>
        //[StringLength(254)]
        //[Key]
        //public string Email { get; set; }

        ///// <summary>
        ///// Имя пользователя
        ///// </summary>
        //[StringLength(40)]
        //[Required]
        //public string Name { get; set; }

        ///// <summary>
        ///// Фамилия пользователя
        ///// </summary>
        //[StringLength(50)]
        //[Required]
        //public string SurName { get; set; }

        /////// <summary>
        ///// Пароль пользователя от учетной записи
        ///// </summary>
        //[Required]
        //public string Password { get; set; }

        #endregion

        #region Async Methods

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager,
            string authenticationType)
        {
            // Обратите внимание, что authenticationType должен совпадать с типом, определенным в CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Здесь добавьте настраиваемые утверждения пользователя
            return userIdentity;
        }

        #endregion
    }
}
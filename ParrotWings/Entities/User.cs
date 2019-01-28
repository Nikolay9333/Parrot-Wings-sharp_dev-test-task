using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;
using ParrotWings.Interfaces;

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
        [JsonProperty("balance")]
        [Column("balance")]
        public long Balance { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        [StringLength(40)]
        [Required]
        [JsonProperty("name")]
        [Column("name")]
        public string Name { get; set; }

        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        [StringLength(50)]
        [Required]
        [JsonProperty("surname")]
        [Column("surname")]
        public string SurName { get; set; }

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

        #region Sync Methods

        public static User GetUserByEmail(IDbRepository dbRepository, string email)
        {
            var param = new SqlParameter("@email", email);
            var sqlQuery = "SELECT * FROM AspNetUsers " +
                           "WHERE Email = @email";

            var user = dbRepository.ExecuteQuery<User>(sqlQuery, param).FirstOrDefault();

            return user;
        }

        #endregion
    }
}
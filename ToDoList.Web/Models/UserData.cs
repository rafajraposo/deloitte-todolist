using System.Security.Claims;

namespace ToDoList.Web.Models
{
    public class UserData : ClaimsPrincipal
    {
        public int Id => FindFirst(ClaimTypes.NameIdentifier) != null ? int.Parse(FindFirst(ClaimTypes.NameIdentifier).Value) : 0;
        
        public UserData(ClaimsPrincipal claimsPrincipal) : base(claimsPrincipal)
        {
        }
    }
}
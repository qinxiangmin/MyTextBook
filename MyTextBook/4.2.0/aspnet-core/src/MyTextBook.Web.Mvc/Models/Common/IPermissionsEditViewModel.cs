using System.Collections.Generic;
using MyTextBook.Roles.Dto;

namespace MyTextBook.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}
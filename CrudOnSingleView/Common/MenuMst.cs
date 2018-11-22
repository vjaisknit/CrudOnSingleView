using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CrudOnSingleView.Common
{
    public class MenuMst
    {
        [Key]
        public int MenuId { get; set; }
        public string MenuText { get; set; }

        public int? fk_parentId { get; set; }

        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public string AreaName { get; set; }
        public bool IsActive { get; set; }

        public List<MenuMst> MenuList { get; set; }
    }
}
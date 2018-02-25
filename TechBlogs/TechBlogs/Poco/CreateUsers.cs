using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using UIOMatic.Attributes;
using UIOMatic.Enums;
using Umbraco.Core.Persistence;
using Umbraco.Core.Persistence.DatabaseAnnotations;


namespace TechBlogs.Poco
{
    public class CreateUsers
    {

    }

    //[TableName("ODR_OptionCategories")]
    //[PrimaryKey("OptionCategoryId", autoIncrement = true)]
    //[UIOMatic("odr_optioncategories", "ODR_OptionCategories", "ODR_OptionCategories", FolderIcon = "icon-users", ItemIcon = "icon-user", SortColumn = "CreatedBy", SortOrder = "desc", RenderType = UIOMaticRenderType.List)]
    //public class ODR_OptionCategories
    //{
    //    [PrimaryKeyColumn(AutoIncrement = true)]
    //    [UIOMaticField(Name = "OptionCategoryId")]
    //    public int OptionCategoryId { get; set; }

    //    [SpecialDbType(SpecialDbTypes.NTEXT)]
    //    [Required]
    //    [UIOMaticListViewField]
    //    [UIOMaticField(Name = "CategoryDescription", View = UIOMatic.Constants.FieldEditors.Textarea)]
    //    public string CategoryDescription { get; set; }

    //    [Required]
    //    [UIOMaticListViewField]
    //    [UIOMaticField(Name = "CategoryTitle")]
    //    public string CategoryTitle { get; set; }

    //    [Required]
    //    [UIOMaticListViewField]
    //    [UIOMaticField(Name = "ContractTypeId", View = "dropdown", Config = "{'typeAlias': 'odr_contracttypes', 'valueColumn': 'ContractTypeId', 'textTemplate' : '{{ContractScheme}}'}")]
    //    public int ContractTypeId { get; set; }

    //    [Required]
    //    [UIOMaticListViewField(Config = "{'format' : '{{value | date:\"dd/MM/yyyy\"}}'}")]
    //    [UIOMaticField(Name = "StartDate", View = UIOMatic.Constants.FieldEditors.DateTime)]
    //    public DateTime StartDate { get; set; }

    //    [Required]
    //    [UIOMaticListViewField(Config = "{'format' : '{{value | date:\"dd/MM/yyyy\"}}'}")]
    //    [UIOMaticField(Name = "EndDate", View = UIOMatic.Constants.FieldEditors.DateTime)]
    //    public DateTime EndDate { get; set; }

    //    [Required]
    //    [UIOMaticListViewField]
    //    [UIOMaticField(Name = "CreatedBy")]
    //    public string CreatedBy { get; set; }


    //    [UIOMaticField(Name = "CreatedDate", View = UIOMatic.Constants.FieldEditors.DateTime)]
    //    public DateTime CreatedDate { get; set; }

    //    [Required]
    //    [UIOMaticListViewField]
    //    [UIOMaticField(Name = "ModifiedBy")]
    //    public string ModifiedBy { get; set; }


    //    [UIOMaticField(Name = "ModifiedDate", View = UIOMatic.Constants.FieldEditors.DateTime)]
    //    public DateTime ModifiedDate { get; set; }
    //}
}
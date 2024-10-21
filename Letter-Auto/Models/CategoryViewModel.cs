namespace Letter_Auto.Models;

using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

public class CategoryViewModel
{
    public Category Category { get; set; }
    public IEnumerable<SelectListItem> Categories { get; set; }
}
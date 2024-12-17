﻿using Microsoft.AspNetCore.Mvc.RazorPages;

public class PrivacyModel : PageModel
{
    public int Counter { get; private set; }
    public void OnGet()
    {
        Counter = HttpContext.Session.GetInt32("Counter") ?? 1;
    }
    public void OnPost()
    {
        Counter = HttpContext.Session.GetInt32("Counter") ?? 1;
        Counter++;
        HttpContext.Session.SetInt32("Counter", Counter);
    }
}

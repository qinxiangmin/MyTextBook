using Abp.Localization;
using System.Collections.Generic;

namespace MyTextBook.Configuration.Ui
{
    public static class UiThemes
    {
        public static List<UiThemeInfo> All { get; }
       
        static UiThemes()
        {
            All = new List<UiThemeInfo>
            {
                new UiThemeInfo( LocalizationHelper.GetString("MyTextBook", "Red"), "red"),
                new UiThemeInfo(LocalizationHelper.GetString("MyTextBook", "Pink"), "pink"),
                new UiThemeInfo(LocalizationHelper.GetString("MyTextBook", "Purple"), "purple"),
                new UiThemeInfo(LocalizationHelper.GetString("MyTextBook", "DeepPurple"),"deep-purple"),
                new UiThemeInfo(LocalizationHelper.GetString("MyTextBook", "Indigo"),"indigo"),
                new UiThemeInfo(LocalizationHelper.GetString("MyTextBook", "Blue"),"blue"),
                new UiThemeInfo(LocalizationHelper.GetString("MyTextBook", "LightBlue"),"light-blue"),
                new UiThemeInfo(LocalizationHelper.GetString("MyTextBook", "Cyan"), "cyan"),
                new UiThemeInfo(LocalizationHelper.GetString("MyTextBook", "Teal"), "teal"),
                new UiThemeInfo(LocalizationHelper.GetString("MyTextBook", "Green"),"green"),
                new UiThemeInfo(LocalizationHelper.GetString("MyTextBook", "LightGreen"),"light-green"),
                new UiThemeInfo(LocalizationHelper.GetString("MyTextBook", "Lime"),"lime"),
                new UiThemeInfo(LocalizationHelper.GetString("MyTextBook", "Yellow"),"yellow"),
                new UiThemeInfo(LocalizationHelper.GetString("MyTextBook", "Amber"),"amber"),
                new UiThemeInfo(LocalizationHelper.GetString("MyTextBook", "Orange"),"orange"),
                new UiThemeInfo(LocalizationHelper.GetString("MyTextBook", "DeepOrange"), "deep-orange"),
                new UiThemeInfo(LocalizationHelper.GetString("MyTextBook", "Brown"),"brown"),
                new UiThemeInfo(LocalizationHelper.GetString("MyTextBook", "Grey"), "grey"),
                new UiThemeInfo(LocalizationHelper.GetString("MyTextBook", "BlueGrey"), "blue-grey"),
                new UiThemeInfo(LocalizationHelper.GetString("MyTextBook", "Black"),"black")
            };
        }
    }
}

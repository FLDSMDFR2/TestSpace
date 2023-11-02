using System.Collections.Generic;
using UnityEngine;

public class Colors
{
    public class ComplementaryColors
    {
        public Color color;
        public Color color2;
    }

    public static List<Color> colorsList = new List<Color>();


    private static Colors instance = null;
    public static Colors Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Colors();
                instance.CreateColors();
            }
            return instance;
        }
    }

    #region Colors
    protected virtual void CreateColors()
    {
        colorsList.Add(GetColorFromHex("#0048BA"));
        colorsList.Add(GetColorFromHex("#B0BF1A"));
        colorsList.Add(GetColorFromHex("#7CB9E8"));
        colorsList.Add(GetColorFromHex("#B284BE"));
        colorsList.Add(GetColorFromHex("#72A0C1"));
        colorsList.Add(GetColorFromHex("#F0F8FF"));
        colorsList.Add(GetColorFromHex("#DB2D43"));
        colorsList.Add(GetColorFromHex("#C46210"));
        colorsList.Add(GetColorFromHex("#EED9C4"));
        colorsList.Add(GetColorFromHex("#9F2B68"));
        colorsList.Add(GetColorFromHex("#F19CBB"));
        colorsList.Add(GetColorFromHex("#AB274F"));
        colorsList.Add(GetColorFromHex("#3B7A57"));
        colorsList.Add(GetColorFromHex("#FFBF00"));
        colorsList.Add(GetColorFromHex("#9966CC"));
        colorsList.Add(GetColorFromHex("#3DDC84"));
        colorsList.Add(GetColorFromHex("#C88A65"));
        colorsList.Add(GetColorFromHex("#665D1E"));
        colorsList.Add(GetColorFromHex("#915C83"));
        colorsList.Add(GetColorFromHex("#841B2D"));
        colorsList.Add(GetColorFromHex("#FAEBD7"));
        colorsList.Add(GetColorFromHex("#FBCEB1"));
        colorsList.Add(GetColorFromHex("#00FFFF"));
        colorsList.Add(GetColorFromHex("#7FFFD4"));
        colorsList.Add(GetColorFromHex("#D0FF14"));
        colorsList.Add(GetColorFromHex("#4B6F44"));
        colorsList.Add(GetColorFromHex("#E9D66B"));
        colorsList.Add(GetColorFromHex("#B2BEB5"));
        colorsList.Add(GetColorFromHex("#FF9966"));
        colorsList.Add(GetColorFromHex("#FDEE00"));
        colorsList.Add(GetColorFromHex("#007FFF"));
        colorsList.Add(GetColorFromHex("#F0FFFF"));
        colorsList.Add(GetColorFromHex("#89CFF0"));
        colorsList.Add(GetColorFromHex("#A1CAF1"));
        colorsList.Add(GetColorFromHex("#F4C2C2"));
        colorsList.Add(GetColorFromHex("#FEFEFA"));
        colorsList.Add(GetColorFromHex("#FF91AF"));
        colorsList.Add(GetColorFromHex("#FAE7B5"));
        colorsList.Add(GetColorFromHex("#DA1884"));
        colorsList.Add(GetColorFromHex("#7C0A02"));
        colorsList.Add(GetColorFromHex("#848482"));
        colorsList.Add(GetColorFromHex("#BCD4E6"));
        colorsList.Add(GetColorFromHex("#9F8170"));
        colorsList.Add(GetColorFromHex("#F5F5DC"));
        colorsList.Add(GetColorFromHex("#2E5894"));
        colorsList.Add(GetColorFromHex("#9C2542"));
        colorsList.Add(GetColorFromHex("#FFE4C4"));
        colorsList.Add(GetColorFromHex("#3D2B1F"));
        colorsList.Add(GetColorFromHex("#967117"));
        colorsList.Add(GetColorFromHex("#CAE00D"));
        colorsList.Add(GetColorFromHex("#000000"));
        colorsList.Add(GetColorFromHex("#3D0C02"));
        colorsList.Add(GetColorFromHex("#54626F"));
        colorsList.Add(GetColorFromHex("#3B3C36"));
        colorsList.Add(GetColorFromHex("#BFAFB2"));
        colorsList.Add(GetColorFromHex("#FFEBCD"));
        colorsList.Add(GetColorFromHex("#A57164"));
        colorsList.Add(GetColorFromHex("#318CE7"));
        colorsList.Add(GetColorFromHex("#ACE5EE"));
        colorsList.Add(GetColorFromHex("#660000"));
        colorsList.Add(GetColorFromHex("#0000FF"));
        colorsList.Add(GetColorFromHex("#1F75FE"));
        colorsList.Add(GetColorFromHex("#0093AF"));
        colorsList.Add(GetColorFromHex("#0087BD"));
        colorsList.Add(GetColorFromHex("#0018A8"));
        colorsList.Add(GetColorFromHex("#333399"));
        colorsList.Add(GetColorFromHex("#A2A2D0"));
        colorsList.Add(GetColorFromHex("#6699CC"));
        colorsList.Add(GetColorFromHex("#5DADEC"));
        colorsList.Add(GetColorFromHex("#126180"));
        colorsList.Add(GetColorFromHex("#8A2BE2"));
        colorsList.Add(GetColorFromHex("#5072A7"));
        colorsList.Add(GetColorFromHex("#3C69E7"));
        colorsList.Add(GetColorFromHex("#DE5D83"));
        colorsList.Add(GetColorFromHex("#79443B"));
        colorsList.Add(GetColorFromHex("#E3DAC9"));
        colorsList.Add(GetColorFromHex("#CB4154"));
        colorsList.Add(GetColorFromHex("#D891EF"));
        colorsList.Add(GetColorFromHex("#FFAA1D"));
        colorsList.Add(GetColorFromHex("#004225"));
        colorsList.Add(GetColorFromHex("#CD7F32"));
        colorsList.Add(GetColorFromHex("#964B00"));
        colorsList.Add(GetColorFromHex("#AF6E4D"));
        colorsList.Add(GetColorFromHex("#7BB661"));
        colorsList.Add(GetColorFromHex("#FFC680"));
        colorsList.Add(GetColorFromHex("#800020"));
        colorsList.Add(GetColorFromHex("#DEB887"));
        colorsList.Add(GetColorFromHex("#A17A74"));
        colorsList.Add(GetColorFromHex("#CC5500"));
        colorsList.Add(GetColorFromHex("#E97451"));
        colorsList.Add(GetColorFromHex("#8A3324"));
        colorsList.Add(GetColorFromHex("#BD33A4"));
        colorsList.Add(GetColorFromHex("#702963"));
        colorsList.Add(GetColorFromHex("#5F9EA0"));
        colorsList.Add(GetColorFromHex("#91A3B0"));
        colorsList.Add(GetColorFromHex("#006B3C"));
        colorsList.Add(GetColorFromHex("#ED872D"));
        colorsList.Add(GetColorFromHex("#A67B5B"));
        colorsList.Add(GetColorFromHex("#4B3621"));
        colorsList.Add(GetColorFromHex("#A3C1AD"));
        colorsList.Add(GetColorFromHex("#C19A6B"));
        colorsList.Add(GetColorFromHex("#EFBBCC"));
        colorsList.Add(GetColorFromHex("#FFFF99"));
        colorsList.Add(GetColorFromHex("#FFEF00"));
        colorsList.Add(GetColorFromHex("#E4717A"));
        colorsList.Add(GetColorFromHex("#C41E3A"));
        colorsList.Add(GetColorFromHex("#00CC99"));
        colorsList.Add(GetColorFromHex("#960018"));
        colorsList.Add(GetColorFromHex("#D70040"));
        colorsList.Add(GetColorFromHex("#FFA6C9"));
        colorsList.Add(GetColorFromHex("#B31B1B"));
        colorsList.Add(GetColorFromHex("#56A0D3"));
        colorsList.Add(GetColorFromHex("#ED9121"));
        colorsList.Add(GetColorFromHex("#703642"));
        colorsList.Add(GetColorFromHex("#C95A49"));
        colorsList.Add(GetColorFromHex("#ACE1AF"));
        colorsList.Add(GetColorFromHex("#B2FFFF"));
        colorsList.Add(GetColorFromHex("#DE3163"));
        colorsList.Add(GetColorFromHex("#007BA7"));
        colorsList.Add(GetColorFromHex("#2A52BE"));
        colorsList.Add(GetColorFromHex("#6D9BC3"));
        colorsList.Add(GetColorFromHex("#1DACD6"));
        colorsList.Add(GetColorFromHex("#0040FF"));
        colorsList.Add(GetColorFromHex("#F7E7CE"));
        colorsList.Add(GetColorFromHex("#F1DDCF"));
        colorsList.Add(GetColorFromHex("#36454F"));
        colorsList.Add(GetColorFromHex("#E68FAC"));
        colorsList.Add(GetColorFromHex("#80FF00"));
        colorsList.Add(GetColorFromHex("#FFB7C5"));
        colorsList.Add(GetColorFromHex("#954535"));
        colorsList.Add(GetColorFromHex("#E23D28"));
        colorsList.Add(GetColorFromHex("#DE6FA1"));
        colorsList.Add(GetColorFromHex("#AA381E"));
        colorsList.Add(GetColorFromHex("#856088"));
        colorsList.Add(GetColorFromHex("#FFB200"));
        colorsList.Add(GetColorFromHex("#7B3F00"));
        colorsList.Add(GetColorFromHex("#D2691E"));
        colorsList.Add(GetColorFromHex("#98817B"));
        colorsList.Add(GetColorFromHex("#E34234"));
        colorsList.Add(GetColorFromHex("#CD607E"));
        colorsList.Add(GetColorFromHex("#E4D00A"));
        colorsList.Add(GetColorFromHex("#9FA91F"));
        colorsList.Add(GetColorFromHex("#7F1734"));
        colorsList.Add(GetColorFromHex("#6F4E37"));
        colorsList.Add(GetColorFromHex("#B9D9EB"));
        colorsList.Add(GetColorFromHex("#F88379"));
        colorsList.Add(GetColorFromHex("#8C92AC"));
        colorsList.Add(GetColorFromHex("#B87333"));
        colorsList.Add(GetColorFromHex("#DA8A67"));
        colorsList.Add(GetColorFromHex("#AD6F69"));
        colorsList.Add(GetColorFromHex("#CB6D51"));
        colorsList.Add(GetColorFromHex("#996666"));
        colorsList.Add(GetColorFromHex("#FF3800"));
        colorsList.Add(GetColorFromHex("#FF7F50"));
        colorsList.Add(GetColorFromHex("#F88379"));
        colorsList.Add(GetColorFromHex("#893F45"));
        colorsList.Add(GetColorFromHex("#FBEC5D"));
        colorsList.Add(GetColorFromHex("#6495ED"));
        colorsList.Add(GetColorFromHex("#FFF8DC"));
        colorsList.Add(GetColorFromHex("#2E2D88"));
        colorsList.Add(GetColorFromHex("#FFF8E7"));
        colorsList.Add(GetColorFromHex("#81613C"));
        colorsList.Add(GetColorFromHex("#FFBCD9"));
        colorsList.Add(GetColorFromHex("#FFFDD0"));
        colorsList.Add(GetColorFromHex("#DC143C"));
        colorsList.Add(GetColorFromHex("#9E1B32"));
        colorsList.Add(GetColorFromHex("#F5F5F5"));
        colorsList.Add(GetColorFromHex("#00FFFF"));
        colorsList.Add(GetColorFromHex("#00B7EB"));
        colorsList.Add(GetColorFromHex("#58427C"));
        colorsList.Add(GetColorFromHex("#FFD300"));
        colorsList.Add(GetColorFromHex("#F56FA1"));
        colorsList.Add(GetColorFromHex("#FED85D"));
        colorsList.Add(GetColorFromHex("#654321"));
        colorsList.Add(GetColorFromHex("#5D3954"));
        colorsList.Add(GetColorFromHex("#008B8B"));
        colorsList.Add(GetColorFromHex("#536878"));
        colorsList.Add(GetColorFromHex("#B8860B"));
        colorsList.Add(GetColorFromHex("#006400"));
        colorsList.Add(GetColorFromHex("#1A2421"));
        colorsList.Add(GetColorFromHex("#BDB76B"));
        colorsList.Add(GetColorFromHex("#483C32"));
        colorsList.Add(GetColorFromHex("#543D37"));
        colorsList.Add(GetColorFromHex("#8B008B"));
        colorsList.Add(GetColorFromHex("#556B2F"));
        colorsList.Add(GetColorFromHex("#FF8C00"));
        colorsList.Add(GetColorFromHex("#9932CC"));
        colorsList.Add(GetColorFromHex("#301934"));
        colorsList.Add(GetColorFromHex("#8B0000"));
        colorsList.Add(GetColorFromHex("#E9967A"));
        colorsList.Add(GetColorFromHex("#8FBC8F"));
        colorsList.Add(GetColorFromHex("#3C1414"));
        colorsList.Add(GetColorFromHex("#8CBED6"));
        colorsList.Add(GetColorFromHex("#483D8B"));
        colorsList.Add(GetColorFromHex("#2F4F4F"));
        colorsList.Add(GetColorFromHex("#177245"));
        colorsList.Add(GetColorFromHex("#00CED1"));
        colorsList.Add(GetColorFromHex("#9400D3"));
        colorsList.Add(GetColorFromHex("#555555"));
        colorsList.Add(GetColorFromHex("#DA3287"));
        colorsList.Add(GetColorFromHex("#FAD6A5"));
        colorsList.Add(GetColorFromHex("#B94E48"));
        colorsList.Add(GetColorFromHex("#004B49"));
        colorsList.Add(GetColorFromHex("#FF1493"));
        colorsList.Add(GetColorFromHex("#FF9933"));
        colorsList.Add(GetColorFromHex("#00BFFF"));
        colorsList.Add(GetColorFromHex("#4A646C"));
        colorsList.Add(GetColorFromHex("#7E5E60"));
        colorsList.Add(GetColorFromHex("#1560BD"));
        colorsList.Add(GetColorFromHex("#2243B6"));
        colorsList.Add(GetColorFromHex("#C19A6B"));
        colorsList.Add(GetColorFromHex("#EDC9AF"));
        colorsList.Add(GetColorFromHex("#696969"));
        colorsList.Add(GetColorFromHex("#1E90FF"));
        colorsList.Add(GetColorFromHex("#4A412A"));
        colorsList.Add(GetColorFromHex("#00009C"));
        colorsList.Add(GetColorFromHex("#EFDFBB"));
        colorsList.Add(GetColorFromHex("#555D50"));
        colorsList.Add(GetColorFromHex("#C2B280"));
        colorsList.Add(GetColorFromHex("#1B1B1B"));
        colorsList.Add(GetColorFromHex("#614051"));
        colorsList.Add(GetColorFromHex("#F0EAD6"));
        colorsList.Add(GetColorFromHex("#CCFF00"));
        colorsList.Add(GetColorFromHex("#BF00FF"));
        colorsList.Add(GetColorFromHex("#8F00FF"));
        colorsList.Add(GetColorFromHex("#50C878"));
        colorsList.Add(GetColorFromHex("#6C3082"));
        colorsList.Add(GetColorFromHex("#B48395"));
        colorsList.Add(GetColorFromHex("#AB4B52"));
        colorsList.Add(GetColorFromHex("#CC474B"));
        colorsList.Add(GetColorFromHex("#563C5C"));
        colorsList.Add(GetColorFromHex("#00FF40"));
        colorsList.Add(GetColorFromHex("#96C8A2"));
        colorsList.Add(GetColorFromHex("#C19A6B"));
        colorsList.Add(GetColorFromHex("#801818"));
        colorsList.Add(GetColorFromHex("#B53389"));
        colorsList.Add(GetColorFromHex("#DE5285"));
        colorsList.Add(GetColorFromHex("#E5AA70"));
        colorsList.Add(GetColorFromHex("#4F7942"));
        colorsList.Add(GetColorFromHex("#6C541E"));
        colorsList.Add(GetColorFromHex("#FF5470"));
        colorsList.Add(GetColorFromHex("#683068"));
        colorsList.Add(GetColorFromHex("#B22222"));
        colorsList.Add(GetColorFromHex("#CE2029"));
        colorsList.Add(GetColorFromHex("#E25822"));
        colorsList.Add(GetColorFromHex("#EEDC82"));
        colorsList.Add(GetColorFromHex("#A2006D"));
        colorsList.Add(GetColorFromHex("#FFFAF0"));
        colorsList.Add(GetColorFromHex("#228B22"));
        colorsList.Add(GetColorFromHex("#A67B5B"));
        colorsList.Add(GetColorFromHex("#856D4D"));
        colorsList.Add(GetColorFromHex("#0072BB"));
        colorsList.Add(GetColorFromHex("#FD3F92"));
        colorsList.Add(GetColorFromHex("#86608E"));
        colorsList.Add(GetColorFromHex("#9EFD38"));
        colorsList.Add(GetColorFromHex("#D473D4"));
        colorsList.Add(GetColorFromHex("#FD6C9E"));
        colorsList.Add(GetColorFromHex("#C72C48"));
        colorsList.Add(GetColorFromHex("#77B5FE"));
        colorsList.Add(GetColorFromHex("#8806CE"));
        colorsList.Add(GetColorFromHex("#E936A7"));
        colorsList.Add(GetColorFromHex("#FF00FF"));
        colorsList.Add(GetColorFromHex("#C154C1"));
        colorsList.Add(GetColorFromHex("#E48400"));
        colorsList.Add(GetColorFromHex("#87421F"));
    }
    protected virtual Color GetColorFromHex(string hex)
    {
        ColorUtility.TryParseHtmlString(hex, out Color myColor);
        return myColor;
    }
    #endregion

    public virtual int GetColorsCount()
    {
        return colorsList.Count;
    }

    public virtual ComplementaryColors GetComplementaryColors(int index)
    {
        if (index < 0 || index >= colorsList.Count) return null;

        var colors = new ComplementaryColors();
        colors.color = colorsList[index];
        colors.color2 = ColorGetComplementaryColor(colorsList[index]);

        return colors;
    }

    protected virtual Color ColorGetComplementaryColor(Color color)
    {
        return new Color(1 - color.r, 1 - color.g, 1 - color.b);
    }
}

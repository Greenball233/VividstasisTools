using System.Text;

namespace VividstasisUtil;

/// <summary>
/// 控制台表格打印工具
/// </summary>
public class ConsoleTableUtil
{
    private static string LineChar;

    private List<ConsoleTableColumn> columns;
    private List<ConsoleTableDataItem> rows;

    /// <summary>
    /// 表格总宽
    /// </summary>
    private int totalWidth;

    /// <summary>
    /// 表格标题文本
    /// </summary>
    public string TableTitleText { get; set; }

    /// <summary>
    /// 表格尾部文本
    /// </summary>
    public string TableTailText { get; set; }

    public ConsoleTableUtil()
    {
        LineChar = Environment.NewLine;
        columns = new List<ConsoleTableColumn>();
        rows = new List<ConsoleTableDataItem>();
        totalWidth = 1;
    }

    /// <summary>
    /// 添加表列
    /// </summary>
    /// <param name="name">列名</param>
    /// <param name="alignment">排列方式</param>
    /// <param name="width">宽，一个字符为一个宽度</param>
    public void AddTableColumn(string name, TextAlignment alignment, int width)
    {
        totalWidth += width + 1;
        lock (columns)
        {
            ConsoleTableColumn column = new ConsoleTableColumn();
            column.Index = columns.Count;
            column.Name = name;
            column.Alignment = alignment;
            column.Width = width;
            columns.Add(column);
        }
    }

    /// <summary>
    /// 添加表数据项
    /// </summary>
    /// <param name="item"></param>
    public void AddTableDataItem(ConsoleTableDataItem item)
    {
        lock (rows)
        {
            rows.Add(item);
        }
    }

    public string MakeConsoleTable()
    {
        StringBuilder sb = new StringBuilder();

        lock (this)
        {
            //格式化标题
            if (!string.IsNullOrEmpty(TableTitleText))
                sb.Append(ContentAlignmentFormat(TextAlignment.Center, totalWidth, '-', $"({TableTitleText})") +
                          LineChar);
            else
                sb.Append(GetManySameChar(totalWidth, '-') + LineChar);

            sb.Append(GetManySameChar(totalWidth, '-') + LineChar);

            //格式化列名
            string line = "|";

            List<ConsoleTableColumn> sortCloumns = new List<ConsoleTableColumn>(columns.OrderBy(o => o.Index));

            for (int i = 0; i < sortCloumns.Count; i++)
            {
                ConsoleTableColumn column = sortCloumns[i];
                line += ContentAlignmentFormat(column, ' ', column.Name) + "|";
            }

            sb.Append(line + LineChar);
            sb.Append(GetManySameChar(totalWidth, '-') + LineChar);

            //格式化数据
            foreach (var item in rows)
            {
                string[] strings = new string[sortCloumns.Count];

                foreach (var dataItem in item.dataItemPairs)
                {
                    if (sortCloumns.Count >= dataItem.Key + 1)
                    {
                        strings[dataItem.Key] = ContentAlignmentFormat(sortCloumns[dataItem.Key], ' ', dataItem.Value);
                    }
                }

                sb.Append($"|{string.Join("|", strings)}|{LineChar}");
            }

            //格式化尾标题
            sb.Append(GetManySameChar(totalWidth, '-') + LineChar);

            if (!string.IsNullOrEmpty(TableTailText))
                sb.Append(
                    ContentAlignmentFormat(TextAlignment.Center, totalWidth, '-', $"({TableTailText})") + LineChar);
            else
                sb.Append(GetManySameChar(totalWidth, '-') + LineChar);
        }

        return sb.ToString();
    }

    /// <summary>
    /// 内容排列格式化
    /// </summary>
    /// <param name="alignment">排列方式</param>
    /// <param name="fillChar">填充字符</param>
    /// <param name="width">宽度</param>
    /// <param name="content">内容</param>
    /// <returns></returns>
    public string ContentAlignmentFormat(ConsoleTableColumn column, char fillChar, string content)
    {
        switch (column.Alignment)
        {
            case TextAlignment.Right:
                return ContentRightFormat(fillChar, column.Width, content);
            case TextAlignment.Left:
                return ContentLeftFormat(fillChar, column.Width, content);
            case TextAlignment.Center:
                return ContentCenterFormat(fillChar, column.Width, content);
            default:
                return ContentCenterFormat(fillChar, column.Width, content);
        }
    }

    /// <summary>
    /// 内容排列格式化
    /// </summary>
    /// <param name="alignment"></param>
    /// <param name="width"></param>
    /// <param name="fillChar"></param>
    /// <param name="content"></param>
    /// <returns></returns>
    public string ContentAlignmentFormat(TextAlignment alignment, int width, char fillChar, string content)
    {
        switch (alignment)
        {
            case TextAlignment.Right:
                return ContentRightFormat(fillChar, width, content);
            case TextAlignment.Left:
                return ContentLeftFormat(fillChar, width, content);
            case TextAlignment.Center:
                return ContentCenterFormat(fillChar, width, content);
            default:
                return ContentCenterFormat(fillChar, width, content);
        }
    }

    /// <summary>
    /// 居中内容格式化
    /// </summary>
    /// <param name="fillChar">填充字符</param>
    /// <param name="width">宽度</param>
    /// <param name="content">内容</param>
    /// <returns></returns>
    private string ContentCenterFormat(char fillChar, int width, string content)
    {
        int fillLenght = width - GetContentLenght(content);
        int side = fillLenght / 2;

        int leftSide = side;
        int rightSide = side + (fillLenght % 2 > 0 ? 1 : 0);

        string result = string.Empty;
        result += GetManySameChar(leftSide, fillChar);
        result += content;
        result += GetManySameChar(rightSide, fillChar);

        return result;
    }

    /// <summary>
    /// 居左内容格式化
    /// </summary>
    /// <param name="fillChar">填充字符</param>
    /// <param name="width">宽度</param>
    /// <param name="content">内容</param>
    /// <returns></returns>
    private string ContentLeftFormat(char fillChar, int width, string content)
    {
        int fillLenght = width - GetContentLenght(content);
        int leftSide = 1;
        int rightSide = fillLenght - 1;

        string result = string.Empty;
        result += GetManySameChar(leftSide, fillChar);
        result += content;
        result += GetManySameChar(rightSide, fillChar);

        return result;
    }

    /// <summary>
    /// 居右内容格式化
    /// </summary>
    /// <param name="fillChar">填充字符</param>
    /// <param name="width">宽度</param>
    /// <param name="content">内容</param>
    /// <returns></returns>
    private string ContentRightFormat(char fillChar, int width, string content)
    {
        int fillLenght = width - GetContentLenght(content);
        int leftSide = fillLenght - 1;
        int rightSide = 1;

        string result = string.Empty;
        result += GetManySameChar(leftSide, fillChar);
        result += content;
        result += GetManySameChar(rightSide, fillChar);

        return result;
    }

    /// <summary>
    /// 获取多个相同字符组成的字符串
    /// </summary>
    /// <param name="lenght"></param>
    /// <param name="c"></param>
    /// <returns></returns>
    private string GetManySameChar(int length, char c)
    {
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < length; i++)
        {
            result.Append(c);
        }

        return result.ToString();
    }

    /// <summary>
    /// 获取内容长度
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    private int GetContentLenght(string content)
    {
        int lenght = 0;

        for (int i = 0; i < content.Length; i++)
        {
            if (content[i] >= 0x4e00 && content[i] <= 0x9fbb) lenght += 2;
            else lenght += 1;
        }

        return lenght;
    }
}

/// <summary>
/// 文本排列方式
/// </summary>
public enum TextAlignment
{
    /// <summary>
    /// 文本靠右
    /// </summary>
    Right,

    /// <summary>
    /// 文本靠左
    /// </summary>
    Left,

    /// <summary>
    /// 文本居中
    /// </summary>
    Center,
}

/// <summary>
/// 控制台表格列
/// </summary>
public class ConsoleTableColumn
{
    /// <summary>
    /// 列排序索引
    /// </summary>
    public int Index { get; set; }

    /// <summary>
    /// 列名
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 列宽
    /// </summary>
    public int Width { get; set; }

    /// <summary>
    /// 文本排列方式
    /// </summary>
    public TextAlignment Alignment { get; set; }
}

/// <summary>
/// 控制台表格数据项
/// </summary>
public class ConsoleTableDataItem
{
    public Dictionary<int, string> dataItemPairs { get; set; }

    /// <summary>
    /// 行高
    /// </summary>
    public int Height { get; set; }

    public ConsoleTableDataItem()
    {
        dataItemPairs = new Dictionary<int, string>();
        Height = 1;
    }

    /// <summary>
    /// 添加数据项的列内容
    /// </summary>
    /// <param name="columnIndex">对应列索引</param>
    /// <param name="content">内容</param>
    public void AddItemColumnContent(int columnIndex, string content)
    {
        lock (dataItemPairs)
        {
            if (dataItemPairs.ContainsKey(columnIndex)) dataItemPairs[columnIndex] = content;
            else dataItemPairs.Add(columnIndex, content);
        }
    }

    /// <summary>
    /// 添加数据项的列内容
    /// </summary>
    /// <param name="content">内容</param>
    public void AddItemColumnContent(string content)
    {
        lock (dataItemPairs)
        {
            int columnIndex = dataItemPairs.Count;
            if (dataItemPairs.ContainsKey(columnIndex)) dataItemPairs[columnIndex] = content;
            else dataItemPairs.Add(columnIndex, content);
        }
    }
}
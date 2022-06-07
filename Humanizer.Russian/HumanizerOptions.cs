namespace Humanizer.Russian;

public record HumanizerOptions 
{
    /// <summary>
    ///     Род
    /// </summary>
    public Gender Gender { get; set; }

    /// <summary>
    ///     Форма слова для одной единицы
    /// </summary>
    public string Singular { get; set; }

    /// <summary>
    ///    Форма слова для 2-5 единиц
    /// </summary>
    public string Genitive { get; set; }

    /// <summary>
    ///     Форма слова для 5 и более единиц
    /// </summary>
    public string Plural { get; set; }
}
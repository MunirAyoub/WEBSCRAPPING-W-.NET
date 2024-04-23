using HtmlAgilityPack;

var client = new HttpClient();

try
{
    using var response =
        await client.GetAsync("https://www.db.yugioh-card.com/yugiohdb/card_search.action?ope=2&cid=4041");
    var content = await response.Content.ReadAsStringAsync();
    var doc = new HtmlDocument();

    doc.LoadHtml(content);

    var titleCard = doc.DocumentNode.SelectSingleNode("/html/body/div[1]/div[2]/div/article/div/div[1]/div[1]/h1")
        .InnerText
        .Trim();
    var Attribute = doc.DocumentNode
        .SelectSingleNode("/html/body/div[1]/div[2]/div/article/div/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/span[2]")
        .InnerText
        .Trim();
    var Description = doc.DocumentNode
        .SelectSingleNode("/html/body/div[1]/div[2]/div/article/div/div[1]/div[2]/div[2]/div[2]/div")
        .InnerText
        .Trim()
        .Remove(0, 21);
    
    Console.WriteLine("---------------------------------------------------------------------------");
    Console.WriteLine($"Nome da carta: {titleCard}");
    Console.WriteLine("---------------------------------------------------------------------------");
    Console.WriteLine($"Tipo da carta: {Attribute}");
    Console.WriteLine("---------------------------------------------------------------------------");
    Console.WriteLine($"Descricao da carta: {Description}");
}
catch (Exception erro)
{
    Console.WriteLine($"Esta ocorrendo um erro: {erro.Message}");
}



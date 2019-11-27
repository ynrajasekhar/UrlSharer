# UrlSharer

* UrlSharer gets title, description and thumbnail images
* We can use this information for facebook like linkshare
* It uses [FastImage](https://github.com/ynrajasekhar/FastImage) to get width, height of Images, and returns images if height >=50 && width >= 100 or width >= 50 &&  height >= 100 

### Installation NuGet

    PM> Install-Package UrlSharer

### Example

    UrlInfo urlInfo = UrlSharer.UrlSharer.GetUrlInfo(url);

## Demo

* http://rajlab.apphb.com/UrlSharerDemo.aspx

## Licence

MIT, see file ["MIT-LICENSE"](MIT-LICENSE)

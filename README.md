# UrlSharer

* UrlSharer gets title, description and thumbnail images
* We can use this information for facebook like linkshare
* It uses [FastImage](https://github.com/ynrajasekhar/FastImage) to get width, height of Images, and returns images if height >=200 && width >= 150 or width>=200 &&  height >= 150 

### Installation NuGet

    PM> Install-Package UrlSharer

### Example

    UrlInfo urlInfo = UrlSharer.UrlSharer.GetUrlInfo(url);

## Demo

* http://rajlab.apphb.com/UrlSharerDemo.aspx

## Licence

MIT, see file ["MIT-LICENSE"](MIT-LICENSE)

[![githalytics.com alpha](https://cruel-carlota.pagodabox.com/c975b8428b97cd060336e6306124d910 "githalytics.com")](http://githalytics.com/ynrajasekhar/FastImage)

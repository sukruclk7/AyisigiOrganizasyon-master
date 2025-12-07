using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AyisigiApp.Infrastructure.HtmlHelpers
{
    /// <summary>
    /// Custom Html Helper sınıfı - Proje genelinde tekrar kullanılan HTML yapılarını oluşturur
    /// </summary>
    public static class CustomHtmlHelper
    {
        /// <summary>
        /// Fiyat etiketi oluşturur (Türk Lirası formatında)
        /// </summary>
        /// <param name="html">IHtmlHelper instance</param>
        /// <param name="price">Fiyat değeri</param>
        /// <returns>Formatlanmış fiyat HTML'i</returns>
        public static HtmlString FormatPrice(this IHtmlHelper html, decimal price)
        {
            string formattedPrice = price.ToString("C2", System.Globalization.CultureInfo.GetCultureInfo("tr-TR"));
            return new HtmlString($"<span class='price-badge'>{formattedPrice}</span>");
        }

        /// <summary>
        /// Başlık etiketini Bootstrap sınıfları ile oluşturur
        /// </summary>
        /// <param name="html">IHtmlHelper instance</param>
        /// <param name="title">Başlık metni</param>
        /// <param name="cssClass">CSS sınıfı (opsiyonel)</param>
        /// <returns>Stillendirilmiş başlık HTML'i</returns>
        public static HtmlString PageTitle(this IHtmlHelper html, string title, string cssClass = "display-6")
        {
            return new HtmlString($"<h1 class='{cssClass} text-light'><i class='fa fa-heading text-warning'></i> {title}</h1>");
        }

        /// <summary>
        /// Alert mesajı oluşturur (Bootstrap alert)
        /// </summary>
        /// <param name="html">IHtmlHelper instance</param>
        /// <param name="message">Mesaj içeriği</param>
        /// <param name="alertType">Alert tipi: success, danger, warning, info</param>
        /// <returns>Alert HTML'i</returns>
        public static HtmlString Alert(this IHtmlHelper html, string message, string alertType = "info")
        {
            return new HtmlString($"<div class='alert alert-{alertType} alert-dismissible fade show' role='alert'>{message}<button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button></div>");
        }

        /// <summary>
        /// Buton oluşturur (Bootstrap btn sınıfları ile)
        /// </summary>
        /// <param name="html">IHtmlHelper instance</param>
        /// <param name="text">Buton metni</param>
        /// <param name="url">Buton URL'si</param>
        /// <param name="btnClass">Buton sınıfı (default: btn-primary)</param>
        /// <returns>Buton HTML'i</returns>
        public static HtmlString Button(this IHtmlHelper html, string text, string url, string btnClass = "btn-primary")
        {
            return new HtmlString($"<a href='{url}' class='btn {btnClass}'>{text}</a>");
        }

        /// <summary>
        /// Badge (rozet) oluşturur
        /// </summary>
        /// <param name="html">IHtmlHelper instance</param>
        /// <param name="text">Badge metni</param>
        /// <param name="badgeClass">Badge sınıfı (default: badge-primary)</param>
        /// <returns>Badge HTML'i</returns>
        public static HtmlString Badge(this IHtmlHelper html, string text, string badgeClass = "badge-primary")
        {
            return new HtmlString($"<span class='badge {badgeClass}'>{text}</span>");
        }

        /// <summary>
        /// Sepet simgesi ve sayısı gösterir
        /// </summary>
        /// <param name="html">IHtmlHelper instance</param>
        /// <param name="itemCount">Sepetteki ürün sayısı</param>
        /// <returns>Sepet ikonu HTML'i</returns>
        public static HtmlString CartIcon(this IHtmlHelper html, int itemCount)
        {
            string badge = itemCount > 0 ? $"<span class='badge bg-danger position-absolute top-0 start-100 translate-middle'>{itemCount}</span>" : "";
            return new HtmlString($"<div class='position-relative d-inline-block'><i class='fa fa-shopping-cart fa-2x'></i>{badge}</div>");
        }
    }
}
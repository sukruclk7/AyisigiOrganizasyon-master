/* ==========================================
   AYIÞIÐA - 2025 JavaScript
   ========================================== */

$(document).ready(function () {

    // Arama Kutusunda Enter Tuþu
    $('#searchInput').on('keypress', function (e) {
        if (e.which === 13) {
            searchProducts($(this).val());
            return false;
        }
    });

    // Filtre Butonlarý
    $('. filter-btn').on('click', function () {
        $(this).toggleClass('active');
        applyFilters();
    });

    // Sýralama Seçeneði
    $('#sortSelect').on('change', function () {
        sortProducts($(this).val());
    });

    // Sepete Ekle Butonlarý
    $('. add-to-cart').on('click', function (e) {
        e.preventDefault();
        const productId = $(this).data('product-id');
        addToCart(productId);
    });

    // Favorilere Ekle
    $('.wishlist-btn').on('click', function (e) {
        e.preventDefault();
        $(this).toggleClass('active');
        const icon = $(this).find('i');
        if ($(this).hasClass('active')) {
            icon.removeClass('fa-regular').addClass('fa-solid').css('color', '#AF8A49');
            showNotification('Favorilere eklendi!', 'success');
        } else {
            icon.removeClass('fa-solid').addClass('fa-regular').css('color', '#ccc');
            showNotification('Favorilerden çýkarýldý!', 'info');
        }
    });

    // Sayfa Yüklemesi Sonrasý Animasyon
    $('.product-card').each(function (index) {
        $(this).css({
            'animation-delay': (index * 0.1) + 's'
        });
    });
});

// Ürünleri Ara
function searchProducts(query) {
    if (query.trim() === '') {
        return;
    }
    console.log('Arama: ' + query);
    // AJAX çaðrýsý yapýlabilir
}

// Filtreleri Uygula
function applyFilters() {
    console.log('Filtreler uygulanýyor...');
    // Filtre mantýðý
}

// Ürünleri Sýrala
function sortProducts(sortType) {
    console.log('Sýralama: ' + sortType);
    // Sýralama mantýðý
}

// Sepete Ekle
function addToCart(productId) {
    showNotification('Ürün sepete eklendi!', 'success');
}

// Bildirim Göster
function showNotification(message, type = 'info') {
    const alertClass = type === 'success' ? 'alert-success' : 'alert-' + type;
    const alertHTML = `
        <div class="alert ${alertClass} alert-dismissible fade show" role="alert">
            ${message}
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Kapat"></button>
        </div>
    `;

    $('.notification-container').prepend(alertHTML);

    setTimeout(() => {
        $('.alert:first').fadeOut(function () {
            $(this).remove();
        });
    }, 3000);
}

// Sayfa Kaydýrma Animasyonu
$(window).on('scroll', function () {
    if ($(this).scrollTop() > 100) {
        $('.navbar').addClass('scrolled');
    } else {
        $('.navbar').removeClass('scrolled');
    }
});
function trashSelectedMail() {
    // Seçilen e-postaların ID'lerini al
    var selectedMailIds = [];
    var checkboxes = document.querySelectorAll('input[type="checkbox"][id="delete"]:checked');
    checkboxes.forEach(function (checkbox) {
        selectedMailIds.push(checkbox.value);
    });

    // Seçilen e-postaların ID'leri varsa, silme işlemini gerçekleştir
    if (selectedMailIds.length > 0) {
        Swal.fire({
            title: 'Maili Çöp Kutusuna Taşımak İstediğinizden Eminmisiniz?',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: 'Evet, Taşı',
            cancelButtonText: 'İptal',
            reverseButtons: true
        }).then((result) => {
            if (result.isConfirmed) {
                selectedMailIds.forEach(function (mailId) {
                    // Seçilen e-postaları silmek için AJAX isteği gönder
                    // AJAX isteği kendi proje yapınıza uygun olarak düzenlenmelidir
                    // Örnek istek:
                    $.ajax({
                        type: "POST",
                        url: "/Mail/Trash/" + mailId,

                        success: function (response) {
                            Swal.fire({
                                icon: 'success',
                                title: 'Mesaj Çöp Kutusuna Taşındı!',
                                text: 'Çöp Kutusuna taşıma İşlemi Başarılı.'

                            }).then(() => {
                                // Başarılı silme işlemi sonrasında sayfanın yeniden yüklenmesi
                                location.reload(); // Sayfanın yeniden yüklenmesi
                            });
                        },
                        error: function (xhr, status, error) {
                            // Hata durumunda gereken işlemler yapılabilir
                        }
                    });
                    console.log("Deleting mail with id: " + mailId);
                });
            }
        });
    } else {
        Swal.fire({
            icon: 'warning',
            title: 'Uyarı!',
            text: 'Lütfen silmek için en az bir e-posta seçin.',
            confirmButtonText: 'Tamam'
        });
    }
}
function deleteSelectedMail() {
    // Seçilen e-postaların ID'lerini al
    var selectedMailIds = [];
    var checkboxes = document.querySelectorAll('input[type="checkbox"][id="delete"]:checked');
    checkboxes.forEach(function (checkbox) {
        selectedMailIds.push(checkbox.value);
    });

    // Seçilen e-postaların ID'leri varsa, silme işlemini gerçekleştir
    if (selectedMailIds.length > 0) {
        Swal.fire({
            title: 'Maili Silmek İstediğinizden Eminmisiniz?',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: 'Evet, Sil',
            cancelButtonText: 'İptal',
            reverseButtons: true
        }).then((result) => {
            if (result.isConfirmed) {
                selectedMailIds.forEach(function (mailId) {
                    // Seçilen e-postaları silmek için AJAX isteği gönder
                    // AJAX isteği kendi proje yapınıza uygun olarak düzenlenmelidir
                    // Örnek istek:
                    $.ajax({
                        type: "POST",
                        url: "/Mail/Delete/" + mailId,

                        success: function (response) {
                            Swal.fire({
                                icon: 'success',
                                title: 'Mesaj Silindi!',
                                text: 'Silme İşlemi Başarılı.'

                            }).then(() => {
                                // Başarılı silme işlemi sonrasında sayfanın yeniden yüklenmesi
                                location.reload(); // Sayfanın yeniden yüklenmesi
                            });
                        },
                        error: function (xhr, status, error) {
                            // Hata durumunda gereken işlemler yapılabilir
                        }
                    });
                    console.log("Deleting mail with id: " + mailId);
                });
            }
        });
    } else {
        Swal.fire({
            icon: 'warning',
            title: 'Uyarı!',
            text: 'Lütfen silmek için en az bir e-posta seçin.',
            confirmButtonText: 'Tamam'
        });
    }
}
function junkSelectedMail() {
    // Seçilen e-postaların ID'lerini al
    var selectedMailIds = [];
    var checkboxes = document.querySelectorAll('input[type="checkbox"][id="delete"]:checked');
    checkboxes.forEach(function (checkbox) {
        selectedMailIds.push(checkbox.value);
    });

    // Seçilen e-postaların ID'leri varsa, silme işlemini gerçekleştir
    if (selectedMailIds.length > 0) {
        Swal.fire({
            title: 'Maili Spama Taşımak İstediğinizden Eminmisiniz?',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: 'Evet, Spama Taşı',
            cancelButtonText: 'İptal',
            reverseButtons: true
        }).then((result) => {
            if (result.isConfirmed) {
                selectedMailIds.forEach(function (mailId) {
                    // Seçilen e-postaları silmek için AJAX isteği gönder
                    // AJAX isteği kendi proje yapınıza uygun olarak düzenlenmelidir
                    // Örnek istek:
                    $.ajax({
                        type: "POST",
                        url: "/Mail/MakeJunk/" + mailId,

                        success: function (response) {
                            Swal.fire({
                                icon: 'success',
                                title: 'Spam Kutusuna Taşındı!',
                                text: 'Spam taşıma İşlemi Başarılı.'

                            }).then(() => {
                                // Başarılı silme işlemi sonrasında sayfanın yeniden yüklenmesi
                                location.reload(); // Sayfanın yeniden yüklenmesi
                            });
                        },
                        error: function (xhr, status, error) {
                            // Hata durumunda gereken işlemler yapılabilir
                        }
                    });
                    console.log("Deleting mail with id: " + mailId);
                });
            }
        });
    } else {
        Swal.fire({
            icon: 'warning',
            title: 'Uyarı!',
            text: 'Lütfen silmek için en az bir e-posta seçin.',
            confirmButtonText: 'Tamam'
        });
    }
}

//function filterProducts(filterText) {
//    var rows = document.getElementsByClassName("product-item");
//    for (var i = 0; i < rows.length; i++) {
//        var row = rows[i];
//        var email = row.getAttribute("data-name");
//        if (email.toLowerCase().indexOf(filterText.toLowerCase()) > -1) {
//            row.style.display = "";
//        } else {
//            row.style.display = "none";
//        }
//    }
//}
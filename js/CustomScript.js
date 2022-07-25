var brojac = 0;
window.addEventListener('load', kontaktTogler);
window.addEventListener('resize', kontaktTogler);

function kontaktTogler() {
    brojac = 0;
    var naw = $(".navbar-toggler-icon").is(":visible");
    if (naw == true) {
        scale = 1;
        $(".collapse.navbar-collapse").css({ "text-align": "center" });
        $(".navbar-nav > #kontakt.nav-item > .nav-link").css({ "color": "#efecec", "border": "0px" });
        $(".navbar-nav > #kontakt.nav-item > .nav-link").hover(
            function () {
                $(this).css({ "color": "white", "background": "#28a745" });
            },
            function () {
                $(this).css({ "color": "#efecec", "border": "0px" })
            }
        );
        $(".navbar-nav>.nav-item>.nav-link").css({ "color": "#efecec", "background": "#28a745", "border-bottom": "0px"});
        $(".navbar-nav>.nav-item>.nav-link").hover(
            function () {
                $(this).css({ "color": "white", "background": "#28a745","border-bottom":"0px" });
            },
            function () {
                $(this).css({ "color": "#efecec", "border": "0px" })
            }
        );
        brojac = 1;
    }
    else {
        scale = 1.5;
        $(".navbar-nav>.nav-item>.nav-link").hover(
            function () {
                $(this).css({ "color": "white", "background": "#28a745", "border-bottom": "2px solid white"});
            },
            function () {
                $(this).css({ "color": "#efecec", "background": "#28a745", "border-bottom": "0px"})
            }
        );
        $(".navbar-nav > li.nav-item.active> a.nav-link").css({ "color": "white", "border-bottom": "2px solid white" });
        $(".navbar-nav > li.nav-item.active> a.nav-link").hover(
            function () {
                
                    $(this).css({ "color": "white", "border-bottom": "2px solid white" });
                               
            },
            function () {
                
                    $(this).css({ "color": "white", "border-bottom": "2px solid white" })
                
            }
        );
        $(".navbar-nav > #kontakt.nav-item > .nav-link").css({ "color": "white", "border": "2px solid white", "border-radius": "20px" });
        $(".navbar-nav > #kontakt.nav-item > .nav-link").hover(
            function () {
                $(this).css({ "color": "#28a745", "background": "white", "border-radius": "20px" });
            },
            function () {
                $(this).css({ "color": "white", "background": "#28a745", "border": "2px solid white", "border-radius": "20px" })
            }
        );
        brojac = 2;
    }
}
$(document).ready(function () {
    // get current URL path and assign 'active' class
    var current = document.getElementsByClassName("active");
    if (current.length > 0) {

        current[0].className = current[0].className.replace(" active", "");
    }
    var pathname = window.location.pathname;
    $('.navbar-nav > li > a[href="' + pathname + '"]').parent().addClass('active');
})
function modall(){
    Swal.fire({
        title: 'Poslato!',
        text: "Vaša poruka je uspešno poslata.",
        icon: 'success',
        confirmButtonColor: '#3085d6',
        confirmButtonText: 'U redu'
    })
}
  
function confirmDelete(uniqueId, isDeleteClicked) {
    var deleteSpan = 'deleteSpan_' + uniqueId;
    var confirmDeleteSpan = 'confirmDeleteSpan_' + uniqueId;

    if (isDeleteClicked) {
        $('#' + deleteSpan).hide();
        $('#' + confirmDeleteSpan).show();
    }
    else {
        $('#' + deleteSpan).show();
        $('#' + confirmDeleteSpan).hide();
    }
}
var brojac = 0;
var url;
let scale = 1.5;
function proslediPrvi(idClicked) {
    if (idClicked == 't1') {
        url = '../PDFs/t1.pdf';
    }
    else if (idClicked == 't2') {
        url = '../PDFs/t2.pdf';
    }
    else {
        url = '../PDFs/t3.pdf';
    }
    brojac = 1;
    localStorage.setItem("bs", brojac);
    localStorage.setItem("ur", url);
}
window.onload = function () {
    if (localStorage.getItem("bs") == 1) {
        let pdfDoc = null,
            pageNum = 1,
            pageIsRendering = false,
            pageNumIsPending = null;
        const canvas = document.querySelector('#pdf-render'),
            ctx = canvas.getContext('2d');

        const renderPage = num => {
            pageIsRendering = true;
            pdfDoc.getPage(num).then(page => {
                const viewport = page.getViewport({ scale });
                canvas.height = viewport.height;
                canvas.width = viewport.width;
                const renderCtx = {
                    canvasContext: ctx,
                    viewport
                }
                page.render(renderCtx).promise.then(() => {
                    pageIsRendering = false;
                    if (pageNumIsPending !== null) {
                        renderPage(pageNumIsPending);
                        pageNumIsPending = null;
                    }
                });
                document.querySelector('#page-num').textContent = num;
            });
        };

        const queueRenderPage = num => {
            if (pageIsRendering) {
                pageNumIsPending = num;
            }
            else {
                renderPage(num);
            }
        }

        const showPrevPage = () => {
            if (pageNum <= 1) {
                return;
            }
            pageNum--;
            queueRenderPage(pageNum);
        }

        const showNextPage = () => {
            if (pageNum >= pdfDoc.numPages) {
                return;
            }
            pageNum++;
            queueRenderPage(pageNum);
        }

        pdfjsLib.getDocument(localStorage.getItem("ur")).promise.then(pdfDoc_ => {
            pdfDoc = pdfDoc_;

            document.querySelector('#page-count').textContent = pdfDoc.numPages;

            renderPage(pageNum);
        }).catch(err => {
            const div = document.createElement('div');
            div.className = 'alert text-white bg-danger mb-3';
            div.appendChild(document.createTextNode('PDF fajl se ne moze prikazati.'));
            document.querySelector('#preKanvasa').insertBefore(div, canvas);            
            document.querySelector('#topBar').style.visibility = 'hidden';
            document.querySelector('#topBar').style.height = 0;
            document.querySelector('#pdf-render').style.width = 0;
        });

        document.querySelector('#prev-page').addEventListener('click', showPrevPage);
        document.querySelector('#next-page').addEventListener('click', showNextPage);

        brojac = 0;
    }   
}




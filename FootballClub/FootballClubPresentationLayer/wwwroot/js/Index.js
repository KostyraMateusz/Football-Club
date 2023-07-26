function changeImageOnHover(imageElement, hoverImage) {
    imageElement.src = hoverImage;
}

function restoreOriginalImage(imageElement) {
    imageElement.src = imageElement.dataset.originalSrc;
}

function changeImagesOnRowHover(row) {
    var detailsImage = row.querySelector(".img-action #details");
    var editImage = row.querySelector(".img-action #edit");
    var deleteImage = row.querySelector(".img-action #delete");

    detailsImage.dataset.originalSrc = detailsImage.src;
    editImage.dataset.originalSrc = editImage.src;
    deleteImage.dataset.originalSrc = deleteImage.src;

    changeImageOnHover(detailsImage, "/css/img/detailsBlack.jpg");
    changeImageOnHover(editImage, "/css/img/editBlack.jpg");
    changeImageOnHover(deleteImage, "/css/img/deleteBlack.jpg");
}

function restoreOriginalImagesOnRow(row) {
    var detailsImage = row.querySelector(".img-action #details");
    var editImage = row.querySelector(".img-action #edit");
    var deleteImage = row.querySelector(".img-action #delete");

    restoreOriginalImage(detailsImage);
    restoreOriginalImage(editImage);
    restoreOriginalImage(deleteImage);
}

function setupTableRow(row) {
    var detailsImage = row.querySelector(".img-action #details");
    var editImage = row.querySelector(".img-action #edit");
    var deleteImage = row.querySelector(".img-action #delete");

    row.addEventListener("mouseenter", function () {
        changeImagesOnRowHover(row);
    });
    row.addEventListener("mouseleave", function () {
        restoreOriginalImagesOnRow(row);
    });

    detailsImage.addEventListener("mouseenter", function () {
        changeImageOnHover(detailsImage, "/css/img/detailsHover.jpg");
    });
    detailsImage.addEventListener("mouseleave", function () {
        restoreOriginalImage(changeImageOnHover(detailsImage, "/css/img/detailsBlack.jpg"));
    });

    editImage.addEventListener("mouseenter", function () {
        changeImageOnHover(editImage, "/css/img/editHover.jpg");
    });
    editImage.addEventListener("mouseleave", function () {
        restoreOriginalImage(changeImageOnHover(editImage, "/css/img/editBlack.jpg"));
    });

    deleteImage.addEventListener("mouseenter", function () {
        changeImageOnHover(deleteImage, "/css/img/deleteHover.jpg");
    });
    deleteImage.addEventListener("mouseleave", function () {
        restoreOriginalImage(changeImageOnHover(deleteImage, "/css/img/deleteBlack.jpg"));
    });
}

document.querySelectorAll(".table-row").forEach(function (row) {
    setupTableRow(row);
});
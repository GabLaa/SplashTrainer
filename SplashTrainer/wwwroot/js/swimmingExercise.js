let selectedStyle = '';
let selectedCategory = '';
let exerciseToDeleteId = null;

function selectStyle(style) {
    selectedStyle = style;
    document.getElementById('categoriesSection').style.display = 'block';
    document.getElementById('exercisesSection').style.display = 'none';
}

function selectCategory(category) {
    selectedCategory = category;
    fetch(`/SwimmingExercise/Filter?style=${selectedStyle}&category=${selectedCategory}`)
        .then(response => response.text())
        .then(html => {
            document.getElementById('exerciseList').innerHTML = html;
            document.getElementById('exercisesSection').style.display = 'block';
        });
}

function loadDetails(id) {
    fetch(`/SwimmingExercise/Details/${id}`)
        .then(response => response.text())
        .then(html => {
            document.getElementById('detailsModalContent').innerHTML = html;
            $('#detailsModal').modal('show');
        })
        .catch (error => console.error('Błąd podczas ładowania szczegółów:', error));
}

window.loadDetails = loadDetails;


function loadDeleteModal(id) {
    exerciseToDeleteId = id;
    document.getElementById('deleteConfirmationText').classList.remove('d-none');
    document.getElementById('deleteConfirmationMessage').classList.add('d-none');
    $('#deleteModal').modal('show');
}


function submitAddForm() {
    const form = document.querySelector("form[asp-action='Add']");
    form.addEventListener('submit', function (event) {
        event.preventDefault(); // Zapobiegamy domyślnemu przesyłaniu formularza

        const formData = new FormData(form);

        fetch('/SwimmingExercise/Add', {
            method: 'POST',
            body: formData
        })
            .then(response => response.json())
            .then(data => {
                if (data.success) {
                    // Odśwież tabelę
                    selectCategory(selectedCategory);
                    alert("Ćwiczenie zostało dodane!");
                } else {
                    // Wyświetl błędy walidacji
                    alert("Nie udało się dodać ćwiczenia: " + data.errors.join(", "));
                }
            })
            .catch(error => console.error('Błąd:', error));
    });
}

document.addEventListener('DOMContentLoaded', function () {
    const form = document.getElementById('addExerciseForm');

    if (form) {
        form.addEventListener('submit', function (event) {
            event.preventDefault(); // Zablokuj domyślne przesyłanie formularza

            const formData = new FormData(form);

            fetch('/SwimmingExercise/Add', {
                method: 'POST',
                body: formData
            })
                .then(response => response.json())
                .then(data => {
                    if (data.success) {
                        // Jeśli dodanie zakończyło się sukcesem
                        alert("Ćwiczenie zostało pomyślnie dodane!");
                        form.reset(); // Reset formularza
                        location.reload(); // Odśwież stronę, aby zobaczyć zaktualizowaną tabelę
                    } else {
                        // Jeśli są błędy walidacji
                        alert("Błąd: " + data.errors.join(", "));
                    }
                })
                .catch(error => console.error('Błąd:', error));
        });
    }
});

document.getElementById('confirmDeleteButton').addEventListener('click', function () {
    fetch(`/SwimmingExercise/Delete/${exerciseToDeleteId}`, {
        method: 'DELETE'
    })
        .then(response => {
            if (!response.ok) {
                throw new Error(`HTTP error! status: ${response.status}`);
            }
            return response.json();
        })
        .then(data => {
            if (data.success) {
                // Ukryj przyciski w modalu
                document.getElementById('deleteModalFooter').classList.add('d-none');

                // Wyświetl komunikat o sukcesie w modalnym oknie
                document.getElementById('deleteConfirmationText').classList.add('d-none');
                document.getElementById('deleteConfirmationMessage').classList.remove('d-none');

                // Odśwież tabelę po krótkim czasie i zmaknij
                setTimeout(() => {
                    $('#deleteModal').modal('hide');
                    //document.getElementById('deleteModalFooter').classList.remove('d-none'); // Przywróć stopkę dla następnego użycia
                    selectCategory(selectedCategory);
                }, 1000);
            } else {
                console.error("Nie udało się usunąć ćwiczenia.");
            }
        })
        .catch(error => console.error('Błąd podczas usuwania ćwiczenia:', error));
});

// Przywracanie przycisków po całkowitym zamknięciu modala
$('#deleteModal').on('hidden.bs.modal', function () {
    document.getElementById('deleteModalFooter').classList.remove('d-none'); // Przywróć stopkę
    document.getElementById('deleteConfirmationText').classList.remove('d-none'); // Przywróć pytanie
    document.getElementById('deleteConfirmationMessage').classList.add('d-none'); // Ukryj komunikat sukcesu
});

// Udostępnij funkcję globalnie, jeśli wywoływana jest w HTML
window.loadDeleteModal = loadDeleteModal;


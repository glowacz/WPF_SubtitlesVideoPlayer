# WPF_SubtitlesVideoPlayer

Aplikacja do tworzenia i edytowania napisów do filmów i ich tłumaczenia. Aplikacja umożliwia wczytanie filmu i stworzenie zsynchronizowanych do niego napisów.


Część laboratoryjna:<br />
• Główne Okno aplikacji (1 punkt):<br />
• Tytuł: "Subtitle Composer"<br />
• Początkowy rozmiar: 1280x800<br />
• Minimalny rozmiar: 640x480<br />
• Aplikacja otwiera się na środku ekranu<br />
• Menu aplikacji (1 punkt):<br />
• Menu "File":<br />
• "Open" (nic nie robi)<br />
• "Exit” Kończy działanie aplikacji<br />
• Menu "Subtitles":<br />
• "Open" (nic nie robi)<br />
• "Save” (nic nie robi)<br />
• "Save Translation” (nic nie robi), włączone jeżeli opcja Translation jest zaznaczona<br />
• "Translation" - zaznaczalne, domyślnie odznaczone<br />
• Menu "Help":<br />
• "About” Pokazuje okno z informacją o aplikacji.<br />
• Wskazówki: IsCheckable, IsChecked, IsEnabled<br />
• Układ aplikacji (1 punkt):<br />
• Podział na 3 części:<br />
• Odtwarzacz wideo (niefunkcjonalny), zajmuje połowę dostępnej wysokości<br />
• Tabela napisów, zajmuje Płowę dostępnej wysokości<br />
• Edycja wybranego napisu z tabeli, zajmuje resztę wysokości, minimalna wysokość 100 pikseli.<br />
• Użytkownik może zmieniać wysokość poszczególnych elementów wymienionych wyżej<br />
• Wskazówki: Grid, GridSplitter<br />
• Tabela napisów (2.5 + 2.5 punktów):<br />
• Tabela (2.5 punktów):<br />
• Tabela zawiera 4 kolumny: "Show Time", "Hide Time", "Text", "Translation"<br />
• Kolumny "Show Time" i "Hide Time" dopasowują swoją szerokość do zawartości kolumny<br />
• Kolumny "Text” i "Translation" zajmują resztę szerokości tabeli po połowie szerokości każda<br />
• Jeżeli menu Translation jest odznaczone to kolumna "Translation” jest ukryta, a kolumna "Text” zajmuje sama resztę szerokości tabeli<br />
• Tabela umożliwia dodanie nowej instancji napisu, jest on dodawany z czasem pokazania i ukrycia będącym maksymalną wartością czasu ukrycia<br />
• Tabela jest domyślnie posortowana względem czasu pokazania napisu, użytkownik nie może zmienić domyślnego sortowania<br />
• Wskazówki: DataGrid, DataGridTextColumn, IValueConverter (bool to Visiblity)<br />

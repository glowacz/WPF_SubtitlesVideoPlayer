# WPF_SubtitlesVideoPlayer

Aplikacja do tworzenia i edytowania napisów do filmów i ich tłumaczenia. Aplikacja umożliwia wczytanie filmu i stworzenie zsynchronizowanych do niego napisów.

Część laboratoryjna:
• Główne Okno aplikacji (1 punkt):
• Tytuł: "Subtitle Composer"
• Początkowy rozmiar: 1280x800
• Minimalny rozmiar: 640x480
• Aplikacja otwiera się na środku ekranu
• Menu aplikacji (1 punkt):
• Menu "File":
• "Open" (nic nie robi)
• "Exit” Kończy działanie aplikacji
• Menu "Subtitles":
• "Open" (nic nie robi)
• "Save” (nic nie robi)
• "Save Translation” (nic nie robi), włączone jeżeli opcja Translation jest zaznaczona
• "Translation" - zaznaczalne, domyślnie odznaczone
• Menu "Help":
• "About” Pokazuje okno z informacją o aplikacji.
• Wskazówki: IsCheckable, IsChecked, IsEnabled
• Układ aplikacji (1 punkt):
• Podział na 3 części:
• Odtwarzacz wideo (niefunkcjonalny), zajmuje połowę dostępnej wysokości
• Tabela napisów, zajmuje Płowę dostępnej wysokości
• Edycja wybranego napisu z tabeli, zajmuje resztę wysokości, minimalna wysokość 100 pikseli.
• Użytkownik może zmieniać wysokość poszczególnych elementów wymienionych wyżej
• Wskazówki: Grid, GridSplitter
• Tabela napisów (2.5 + 2.5 punktów):
• Tabela (2.5 punktów):
• Tabela zawiera 4 kolumny: "Show Time", "Hide Time", "Text", "Translation"
• Kolumny "Show Time" i "Hide Time" dopasowują swoją szerokość do zawartości kolumny
• Kolumny "Text” i "Translation" zajmują resztę szerokości tabeli po połowie szerokości każda
• Jeżeli menu Translation jest odznaczone to kolumna "Translation” jest ukryta, a kolumna "Text” zajmuje sama resztę szerokości tabeli
• Tabela umożliwia dodanie nowej instancji napisu, jest on dodawany z czasem pokazania i ukrycia będącym maksymalną wartością czasu ukrycia
• Tabela jest domyślnie posortowana względem czasu pokazania napisu, użytkownik nie może zmienić domyślnego sortowania
• Wskazówki: DataGrid, DataGridTextColumn, IValueConverter (bool to Visiblity)
• Zawartość tabeli (2.5 punktów):
• W kolumnach "Show Time" i "Hide Tłme” znajdują się wartości typu TłmeSpan
• W kolumnach "Text” i "Translation" znajdują się wartości typu string
• Podwójne kliknięcie w dowolnym polu tabeli pozwala na edycję wartości
• wpisanie niepoprawnej wartości nie powoduje awarii aplikacji
• dla wartości typu TimeSpan przykładowe wartości manny być akceptowane: "0.0", "0.5", "1:12 , 2:03 04",
. "1:23:53”
• Pole typu Timespan jest foramatowane w następujący sposób:
• ogólnie stosowany jest format:
• jeżeli TimeSpan zawiera zera wiodące, to są one ucinane, np. jest wyświetlane jako
• jeżeli TimeSpan nie zawiera części ułamkowej sekund, to nie jest ona wyświetlana, np. "12:05:35.000" jest wyświetlane jako "12:05:35"
• Wskazówki: DataGridTextColumn, IValueConverter (TimeSpan to string)

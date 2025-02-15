# WPF_SubtitlesVideoPlayer
![screen](https://github.com/glowacz/WPF_SubtitlesVideoPlayer/assets/94084660/e0eff60c-f481-45cf-b7d4-74ef31586ff3)


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
• Zawartość tabeli (2.5 punktów):<br />
• W kolumnach "Show Time" i "Hide Time" znajdują się wartości typu TłmeSpan<br />
• W kolumnach "Text” i "Translation" znajdują się wartości typu string<br />
• kliknięcie w dowolnym polu tabeli pozwala na edycję wartości<br />
• wpisanie niepoprawnej wartości nie powoduje awarii aplikacji<br />
• dla wartości typu TimeSpan przykładowe wartości powinny być akceptowane: 0 , 00 , 05 1•12 2 03 04", "<br />
• Pole typu Timespan jest foramatowane w następujący sposób:<br />
• ogólnie stosowany jest format:<br />
• jeżeli TimeSpan zawiera zera wiodące, to są one ucinane, np. jest wyświetlane jako «4:05.903"<br />
• jeżeli TimeSpan nie zawiera części ułamkowej sekund, to nie jest ona wyświetlana, np. "12:05:35.000" jest wyświetlane jako "12:05:35”<br />
• Wskazówki: DataGridTextColumn, IValueConverter (TimeSpan to string)<br />
• Edycja wybranego napisu z tabeli (2 + 2 punktów)<br />
• Wybranie pozycji w tabeli umożliwia edycję instancji napisu za pomocą tej kontrolki<br />
• Edycja czasu (2 punkty):<br />
• Szerokość tej części wyznaczana jest automatycznie na podstawie zawartości<br />
• Pole "Show” - czas pojawienia się napisu<br />
• Pole "Hide” - czas zniknięcia napisu<br />
• Pole "Duration” - czas wyświetlania napisu, obliczane automatycznie na podstawie dwóch poprzednich pól "Show” i "Hide"<br />
• Pola te umożliwiaja edycję odpowiedniego pola typu TimeSpan, zasady formatowania i akceptowane wartości tak jak opisane to było wcześniej<br />
• Zmiana w "Duration” wywołuje odpowiednią zmianę w polu "Hide"<br />
• Zmiana dowolnego pola odzwierciedlana jest automatycznie w tabeli<br />
• Wskazówki: UpdateSourceTrigger, OnPropertyChanged<br />
• Edycja tekstu i translacji (2 punkty)<br />
• Pole do edycji tekstu i tłumaczenia zajmują po połowie dostępnej szerokości, jeżeli opcja "Translation” jest wyłączona, to edycja tłumaczenia jest ukryta, a pole do edycji<br />
tekstu zajmuje całą dostępną szerokość<br />
• Pola do edycji tekstu i tłumaczenia umożliwiają wprowadzenie znaku nowej lini, ich zawartość jest wyśrodkowana, tekst automatycznie się zawija, a w razie potrzeby<br />
pokazywany jest wertykalny Scrollbar<br />
• Jeżeli menu Translation jest odznaczone to kolumna "Translation” jest ukryta, a kolumna "Text” zajmuje sama resztę szerokości tabeli<br />
• Tabela umożliwia dodanie nowej instancji napisu, jest on dodawany z czasem pokazania i ukrycia będącym maksymalną wartością czasu ukrycia<br />
• Tabela jest domyślnie posortowana względem czasu pokazania napisu, użytkownik nie może zmienić domyślnego sortowania<br />
• Wskazówki: DataGrid, DataGridTextColumn, IValueConverter (bool to Visiblity)<br />

• Odtwarzacz wideo (2 punkty)<br />
• Menu "Open” pozwala wybrać i otworzyć plik wideo<br />
• Scroll myszy nad kontrolką odtwarzacza pozwala zmieniać głośność wideo<br />
• Kliknięcie na odtwarzacz odtwarza/pauzuje wideo<br />
• Wybranie napisu z tabeli napisów powoduje przesunięcie odtwarzania do czasu pokazania napisu<br />
• Odtwarzacz wideo - kontrolki (3 punkty)<br />
• Przyciski "Play", "Pause", "Stop", które odpowiednio: włączają odtwarzanie wideo, wstrzymują odtwarzanie wideo, wstrzymują odtwarzanie wideo + reserują pozycję odtwarzacza,<br />
Przyciski te wykorzystują dołączonych do zadania grafik "play.png", "pause.png", "stop.png”.<br />
• Tekst z informacją o obecnej pozycji odtwarzania w formacie "hh:mm:ss.fff”<br />
• Slider pokazujący obecną pozycję odtwarzania, pozwalający ją zmienić<br />
• Slider pokazujący obecną głośność odtwarzania pozwalający ją zmienić<br />
• Odtwarzacz wideo - napisy (2 punkty)<br />
• Nad odtwarzaczem, w jego dolnej części na środku wyświetlane są napisy<br />
• tekst napisów jest wyśrodkowany<br />
• napisy są koloru białego<br />
• tło napisów jest czarne z 50% przeźroczystością<br />
• Padding napisów jest ustawiony na 5px<br />
• W chwili czasu t, są wyświetlane wszystkie napisy które powinny się pojawić przed czasem t i zniknąć po czasie t.<br />
• W przypadku gdy więcej niż jeden napis powinien zostać pokazany w jednej chwili, pokazują się one jeden pod drugim w kolejności od tego który pojawił się najwcześniej<br />
• Tabela napisów - menu kontekstowe (2 punkty)<br />
• Opcja "Add” - Dodaje napis o czasie pokazania i ukrycia będącym maksymalnym czasem ukrycia napisu<br />
• Opcja "Add after” - Dodaje napis o czasie pokazania i ukrycia będącym maksymalnym czasem ukrycia napisu wśród obecenie zaznaczonych napisów<br />
• opcja "Delete” - Usuwa zazanaczone napisy<br />
• System pluginów - wczytywanie/zapisywanie napisów (3 punkty)<br />
• System pluginów pozwalający dodać obsługę wczytywania/zapisywania nowego formatu napisu, bez rekompilowania aplikacji<br />
• Po wczytaniu pluginu w menu Translation", pojawiają się opcje wczytywania/zapisywania napisów lub ich tłumaczneia w<br />
odpowiednim formacie<br />
• Plugin dodający obsługę wczytywania/zapisywania napisów w formacie .srt (SubRip)<br />
• Pluginy powinny być zaimplementowane przez stworzenie nowego projektu typu "Class library” i kompilowane być do pliku DLL<br />
• Wskazówka: Pluginy powinny implementować odpowiedni interfejs, np.<br />
public interface ISubtitlesP1ugin<br />
string Name { get; }<br />
string Extention { get; }<br />
ICollection<SubtitleRecord> Load (string path);<br />
void Save (string path, ICollection<SubtitleRecord> subtitles);<br />

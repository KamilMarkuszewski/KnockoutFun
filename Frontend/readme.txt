KnockoutJS upskill
To do :
zrozumienie czym jest MVVM - jakie są odpowiedzialnosci?
czym jest View a czym ViewModel w KnockoutJS
obesrvable ? jak działa
czym sie rozni array.observable() od array.observableArray()
jak dobrze podzielic logike w bindigach (if/foreach)
uzywanie z MVC (odbieranie danych, odsylanie danych z formularzy na serwer)
computed() jak dziala?
rodzaje bindingów
component/template



AutoMapper upskill

TODO:
◾po co AutoMapper
◾uzycie z ViewModelami
◾uzycie z DTO
◾Projections (mapping as dynamic code)
◾Nested mappings
◾uzycie z EntitiyFramework (Select as class)


NSerivceBus upskill
TODO:
konfiguracja środowsika
rodzaje transportów
przesyłanie prostych komunikatów
Sagas
przykłady użycia na produkcji w ******


-----------------------------------------------------------------------------------------------------------------------------------------------

po co AutoMapper - 					no przecież że żeby nie kopiowac kodu mapowania jak jakiś .... co chwilę, co robiłem wiele razy

uzycie z ViewModelami - 			nie rozumiem czemu mapowanie do viewModeli, modeli, DTO czy czegokolwiek miałoby być szczególnie uwzgledniane, 
									poza faktem że np EnfityFramework chciałby mieć np już pousuwane nulle, 
									czy tym, żeby przy update obiektu był to ten sam obiekt który pobraliśmy 

uzycie z DTO - 

Projections 
(mapping as dynamic code) - 		

Nested mappings	- 					

uzycie z EntitiyFramework 
(Select as class) - 				Przy update pobieramy encje i tę samą encję musimy zapisać
									Mapper.Map(book, bookToUpdate);
									
									
									
									

-----------------------------------------------------------------------------------------------------------------------------------------------

Mvvm - 								wiadomo

Czym jest view a czym viewModel - 	view to htmlki, viewModel to obiekt/funkcja JS

Observable - 						var val = 	ko.observable('some value') zwraca funkcję, która jest takim obserwowalnym obiektem, ma geta val() i seta  val('new val), 
									można to bindować data-bind w htmlu, 
									można na to subskrybować żeby wykonac coś na zmianie (subsrypcję trzeba dispose'ować),
									extend -ustawia dodatkowe opcje jak np logowanie, czy notyfikowanie zmian nawet gdy wartość zmienia się na tę samą

Observable vs observableArray -		observableArray pozwala obserwować kolekcję zamiast pojedynczej wartości, (nie znaczy to, że nagle wszystko wewnątrz jest obserwowalne, jedynie kolekcja)
									dostarcza metody takie jak ma zwykła tablica ale działające lepiej (wsparcie przeglądarek, obsługa obserwowalności)
									push, pop, sort, reverse, splice, replace, remove, etc.
									
If, foreach, with/using, let - 		Mamy foreach  <tbody data-bind="foreach: people"> / <!-- ko foreach: myItems -->	/ <ul data-bind="foreach: { data: categories, as: 'category' }">	
									Wewnątrz zmienia się kontekst i używamy nazw pól itemu w pętli, do obiektu po którym iterujemy można się odwołać poprzez $parent, a do licznika $index
									Dla animacji i innych bajerów są funkcje AfterAdd, BeforeRemove etc <ul data-bind="foreach: { data: myItems, afterAdd: yellowFadeIn }">
									
									If, tu bez filozofii <div data-bind="if: someCondition"> / <!-- ko if: someCondition -->, jest też ifnot jak ktoś nie lubi wykrzykników
									
									With / using - to służy do zmiany kontekstu (w taki sposób jak w pętli for zmienia się kontekst na kontekst elementu), różnica jest taka że using jest nowy i nie robi re-renderingu cokolwiek to znaczy.
									
									Let, pozwala ustawić wiele kontekstów pod konkretnymi nazwami. Tych kontekstów można używać w z zagnieżdżonych wewnątrz kontekstach. 
									Przykłądowo prziszemy pętlę w pętli a chcemy się odwoływac jeszcze do innych rzeczy.
									
Knockout + asp.mvc	-				z asp.net mvc można odebrac dane z viewModelu przekazanego do widoku w kontrolerze i parsowac to do jsona (u mnie była to extension metoda) 
									w drugą stronę wysyła się ajaxem za pomocą jQuery w taki sposób: 
									
									$.ajax({
										url: '@Url.Action("Remove", "Home")',
										type: 'POST',
										contentType: 'application/json; charset=utf-8',
										data: "{ id: " + book.id + " }",
										success: function () {
											self.books(self.books().filter(function(value) {
												return value.id != book.is;
											}));
										}
									});
									
									no i w sumie jeśli to są dane w formularzu to można równie dobrze po prostu wysłać ten formularz standardowo
									
Computed observable -				W sumie to analogiczne działanie do computed kolumny w sqlserver. ko.computed przyjmuje funkcję wyliczajacą wartość.
									self.fullName = ko.computed(function() { return self.firstName() + " " + self.lastName();  });
									
									Jako ostatni parametr przekazuje się this, bez tego nie da sie wyliczyć, chyba, ze this zapiszemy w zmiennej (np self) i wtedy jak powyżej.
									
									ko.pureComputed - bardziej wydajna wersja która może być  używana gdy computed to proste wyliczenie na podstawie innych observable
									
									Wydajność.. normalnie computedObservable wylicza się od razu po zmianie w zależnej zmiennej, ale jeśli takich zmiennych jest dużo lepiej to odroczyć aż wszystkie się zmienią.
									
									// Ensure updates no more than once per 50-millisecond period
									myViewModel.fullName.extend({ rateLimit: 50 });
									
Rodzaje bindingów -					Wszystko w htmlu bindujemy za pomocą data-bind. 
									data-bind="text: myMessage"	
									data-bind="html: details"																	jak wyżej ale dla elementów DOM
									data-bind="visible: shouldShowMessage"
									data-bind="class: profitStatus"
									data-bind="css: { my-class: someValue }"
									data-bind="style: { my-class: someValue }"
									data-bind="attr: { href: url, title: details }" 											dowolny atrybut
									data-bind="value: cellphoneNumber, enable: hasCellphone"									
									
									Bindingi dla formularzy i eventów w JS
									<button data-bind="click: incrementClickCounter">Click me</button>							onClick
									<div data-bind="event: { mouseover: enableDetails, mouseout: disableDetails }"> 			onMouseOver etc 
									<button type="submit">Submit</button>														na submit formularza
									<input data-bind="textInput: userName" />
									<input data-bind="hasFocus: isSelected" /> <button data-bind="click: setIsSelected">Set focus of previous field</button>
									<input type="checkbox" data-bind="checked: wantsSpam" />
									<select data-bind="options: availableCountries, selectedOptions: chosenCountries"></select>    
											.. a w viewModelu 
											availableCountries: ko.observableArray(['France', 'Germany', 'Spain'])
											chosenCountries : ko.observableArray(['Germany'])
									<input data-bind="value: someModelProperty, uniqueName: true" /> 							obiekt dostaje unikalny atrybut name



Component i Template - 				Mamy sobie reużywalne komponenty które stają się tagami html jak w angularze.
									
									<like-widget> </like-widget>
									ko.components.register('like-widget', 
									{ 
										viewModel: viewModel, template: template
									}
									
									Zarówno model i template można wywalić do osobnego pliku i ładować za pomocą require. 
									W asp.net taki html można ładować z partial view i wpakować w tag htmlowy template.
									
									W sumie to główny widok w knockout działa w bardzo podobny sposób, mamy viewModel i htmla, tylko jest w inny sposób rejestrowany.
									
									Template:
									
									<div data-bind="template: { name: 'person-template', foreach: people }"></div>
									<script type="text/html" id="person-template">
										<h3 data-bind="text: name"></h3>
										<p>Credits: <span data-bind="text: credits"></span></p>
									</script>
									
									
----------------------------------------------------------------------------------------------------------------------------------------------------------------


konfiguracja środowiska				Do celów nauki jest LearnignTransport i LearningPersistance. Do celów produkcji i devu już trzeba wybrać jakąś inną opcję, zainstalować particularServicePlatform i tam to skonfigurować.

rodzaje transportów					No jest tego trochę. Między innymi MSMQ, Azure Service Bus, RabbitMQ, coś od Amazona.. i jest też SQLServer. 
									W sql serverze leci to do pięciu tabelek audit, error, ServiceControl, ServiceControl.errors ServiceControl.staging.

przesyłanie prostych komunikatów	Komunikat możemy przesłać z obiektu IEndpointInstance lub IMessageHandlerContext za pomocą send i sendLocal (komenda) lub Publish (event).
									Komenda - leci do jednego określonego endpointu, Event jest broadcastowany.
									Wysyłając komendę należy określić endpoint do którego wysyłamy lub konfigurować routing:
									routing.RouteToEndpoint(typeof(ShootCommand), "DestinationEndpoint");
									
									Komendę i event  moze być odebrana klasą implementującą IHandleMessages<ICommand/IEvent> która ma metodę Handle.
									Możliwe jest to też za pomocą sagi która implementuje IAmStartedByMessages które implementuje IHandleMessages.


Sagas								Saga to taka maszyna stanów, która zapina sie na eventy/komendy i ustawia sobie stan gdy coś zostało wykonane, a później sprawdza, czy już wszystko, jeśli tak wykonuje jakąś akcję.
									Saga implementuje Saga<IContainSagaData> oraz IAmStartedByMessages<IEvent/ICommand>, jako IContainSagaData trzeba wstawić klasę która to implementuje, ta klasa będzie trzymała stan.
									Saga ma metodę ConfigureHowToFindSaga w której konfigurujemy mapingi w taki sposób:
									mapper.ConfigureMapping<ShootCommand>(m => m.MessageId).ToSaga(sd => sd.MessageId);
									Gdzie pierwsze messageId to zmienna eventu/komendy, a drugie to zmienna stanu sagi 
									
przykłady użycia na produkcji w **	
									
									









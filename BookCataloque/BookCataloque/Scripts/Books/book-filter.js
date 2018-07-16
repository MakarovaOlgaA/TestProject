var BookFilter = BookFilter || {};

(function () {
    var self = this;
    var filterForm = "#filterForm";
    var dateFormat = 'DD.MM.YYYY';

    self.BookFilterVM = {
        RatingLowerBound: ko.observable(),
        RatingUpperBound: ko.observable(),
        PublicationDateLowerBound: ko.observable(),
        PublicationDateUpperBound: ko.observable(),
        PagesLowerBound: ko.observable(),
        PagesUpperBound: ko.observable(),
        Title: ko.observable(),
        IsValid: ko.observable(true)
    }

    self.Initialize = function () {
        ko.applyBindings(self.BookFilterVM, $(filterForm)[0]);

        $('.datepicker').datetimepicker({
            viewMode: 'days',
            format: dateFormat
        });
    }
}).apply(BookFilter);
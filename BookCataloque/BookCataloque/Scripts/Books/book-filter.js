var BookFilter = BookFilter || {};

(function () {
    var self = this;
    self.vm = {};

    self.filterForm = '';

    function BookFilterVM() {
        var inner = this;

        inner.RatingLowerBound = ko.observable().extend({ number: true, minimalValue: 1.0, maximalValue: 10.0 });
        inner.RatingUpperBound = ko.observable().extend({ number: true, minimalValue: 1.0, maximalValue: 10.0 });

        inner.PublicationDateLowerBound = ko.observable().extend({ pastDate: GlobalSettings.MinimalSupportedDate });
        inner.PublicationDateUpperBound = ko.observable().extend({ pastDate: GlobalSettings.MinimalSupportedDate });

        inner.PagesLowerBound = ko.observable().extend({ integer: true, minimalValue: 1, maximalValue: 10000 });
        inner.PagesUpperBound = ko.observable().extend({ integer: true, minimalValue: 1, maximalValue: 10000 });

        inner.Title = ko.observable();

        inner.Search = function () {
            if (inner.isValid()) {
                BookGrid.Reload();
            }
        };

        inner.ToJS = function () {
            var mapping = {
                'ignore': ["PublicationDateLowerBound", "PublicationDateUpperBound", "Search", "ToJS", "errors"]
            };

            var result = ko.mapping.toJS(inner, mapping);

            result.PublicationDateLowerBound = inner.PublicationDateLowerBound() ? inner.PublicationDateLowerBound()._d : null;
            result.PublicationDateUpperBound = inner.PublicationDateUpperBound() ? inner.PublicationDateUpperBound()._d : null;

            return result;
        }
    };

    self.Initialize = function () {
        self.vm = new BookFilterVM();
        ko.validation.group(self.vm).showAllMessages();
        ko.applyBindings(self.vm, $(self.filterForm)[0]);
    };
}).apply(BookFilter);
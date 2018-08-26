var BookFilter = BookFilter || {};

(function () {
    var self = this;

    self.filterForm = '';

    self.BookFilterVM = function () {
        var inner = this;

        inner.RatingLowerBound = ko.observable().extend({ number: true, minimalValue: 0.0, maximalValue: 10.0 });
        inner.RatingUpperBound = ko.observable().extend({ number: true, minimalValue: 0.0, maximalValue: 10.0 });

        inner.PublicationDateLowerBound = ko.observable().extend({ pastDate: new Date(1753, 0, 1) });
        inner.PublicationDateUpperBound = ko.observable().extend({ pastDate: new Date(1753, 0, 1) });

        inner.PagesLowerBound = ko.observable().extend({ integer: true, minimalValue: 1, maximalValue: 10000 });
        inner.PagesUpperBound = ko.observable().extend({ integer: true, minimalValue: 1, maximalValue: 10000 });

        inner.Title = ko.observable();

        inner.Search = function () {
            if (inner.isValid()) {

            }
        };
    };

    self.Initialize = function () {
        /*custom bindingHandler for error message*/
        ko.bindingHandlers.validationCore = {
            init: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
                var span = document.createElement('span');
                span.className = 'errorStyle';
                var parent = $(element).parent().closest
                    (".input-group");
                if (parent.length > 0) {
                    $(parent).after(span);     
                } else {
                    $(element).after(span);
                }
                ko.applyBindingsToNode(span, { validationMessage: valueAccessor() });
            }
        }; 

        self.vm = new self.BookFilterVM();

        ko.validation.group(self.vm).showAllMessages()

        ko.applyBindings(self.vm, $(self.filterForm)[0]);
    };
}).apply(BookFilter);
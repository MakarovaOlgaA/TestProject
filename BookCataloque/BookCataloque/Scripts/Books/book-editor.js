var BookEditor = BookEditor || {};

(function () {
    var self = this;
    self.vm = new BookEditor();

    self.editingModal = '';
    self.saveUrl = '';

    function BookEditor() {
        var inner = this;

        inner.Rating = ko.observable().extend({ number: true, minimalValue: 1.0, maximalValue: 10.0 });
        inner.PublicationDate = ko.observable().extend({ pastDate: GlobalSettings.MinimalSupportedDate });
        inner.Pages = ko.observable().extend({ integer: true, minimalValue: 1, maximalValue: 10000 });
        inner.Title = ko.observable();

        inner.Save = function () {
            if (inner.isValid()) {
                BookGrid.Reload();
            }
        };
    };

    self.Initialize = function (model) {
        self.vm = ko.mapping.fromJS(model);

        ko.validation.group(self.vm).showAllMessages();

        ko.applyBindings(self.vm, $(self.filterForm)[0]);
    };
}).apply(BookEditor);
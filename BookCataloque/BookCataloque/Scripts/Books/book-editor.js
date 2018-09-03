var BookEditor = BookEditor || {};

(function () {
    var self = this;
    self.vm = {};

    self.editingModal = '';
    self.addUrl = '';
    self.updateUrl = '';
    self.authorsSelect = '';

    function BookEditor() {
        var inner = this;

        inner.Rating = ko.observable().extend({ required: true, number: true, minimalValue: 1.0, maximalValue: 10.0 });
        inner.PublicationDate = ko.observable().extend({ required: true, pastDate: GlobalSettings.MinimalSupportedDate });
        inner.Pages = ko.observable().extend({ required: true, integer: true, minimalValue: 1, maximalValue: 10000 });
        inner.Title = ko.observable().extend({ required: true });
        inner.BookID = ko.observable(null);
        inner.Authors = ko.observableArray([]);

        inner.Saved = ko.observable(false);
        inner.EditingMode = ko.observable(false);

        inner.ToJS = function () {
            var mapping = {
                'ignore': ["PublicationDate", "Saved", "Save", "Clear", "ToJS", "errors"]
            };

            var result = ko.mapping.toJS(inner, mapping);
            result.PublicationDate = inner.PublicationDate() ? inner.PublicationDate()._d : null;

            return result;
        };

        inner.Save = function () {
            if (inner.isValid()) {
                $.ajax({
                    url: inner.EditingMode() ? self.updateUrl : self.addUrl,
                    type: "POST",
                    data: inner.ToJS(),
                    contentType: 'application/json; charset=utf-8'
                }).done(function (result) {
                    inner.Saved(result.success);
                    inner.EditingMode(true);
                });
            }
        };

        inner.Clear = function () {
            inner.Rating(null);
            inner.PublicationDate(null);
            inner.Pages(null);
            inner.Title(null);
            inner.BookID(null);
            inner.Authors([]);

            inner.Saved(false);
            inner.EditingMode(false);
        };
    };

    self.Initialize = function () {
        self.vm = new BookEditor();
        ko.validation.group(self.vm).showAllMessages();
        ko.applyBindings(self.vm, $(self.editingModal)[0]);
    };

    self.OpenEditingModal = function (model) {
        $(self.authorsSelect).val(null).trigger('change');
        self.Fill(model);
        self.vm.Saved(false);
        self.vm.EditingMode(true);
        $(self.editingModal).modal('show'); 
    }

    self.OpenAddingModal = function () {
        $(self.authorsSelect).val(null).trigger('change');
        self.vm.Clear();
        $(self.editingModal).modal('show');
    }

    self.Fill = function (model) {
        self.vm.Rating(model.Rating);
        self.vm.PublicationDate(moment(model.PublicationDate));
        self.vm.Pages(model.Pages);
        self.vm.Title(model.Title);
        self.vm.BookID(model.BookID);
        self.vm.Authors(model.Authors);
    };
}).apply(BookEditor);
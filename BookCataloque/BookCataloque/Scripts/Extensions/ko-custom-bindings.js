ko.bindingHandlers.datepicker = {
    init: function (element, valueAccessor, allBindingsAccessor) {
        var options = allBindingsAccessor().datepickerOptions || {};
        $(element).datetimepicker(options);

        ko.utils.registerEventHandler(element, 'dp.change', function (e) {
            var observable = valueAccessor();
            observable(e.date);
        });
    },

    update: function (element, valueAccessor) {
        var value = ko.utils.unwrapObservable(valueAccessor());
        var current = $(element).data('DateTimePicker').date();

        if (value - current !== 0) {
            if (value === undefined) {
                // passing undefined to datetimepicker will throw an error
                value = null;
            }
            $(element).data('DateTimePicker').date(value);
        }
    }
};

// a trick to work with ko validation plugin
(function () {
    var init = ko.bindingHandlers['datepicker'].init;

    ko.bindingHandlers['datepicker'].init = function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
        init(element, valueAccessor, allBindingsAccessor);
        return ko.bindingHandlers['validationCore'].init(element, valueAccessor, allBindingsAccessor, viewModel, bindingContext);
    };
}());

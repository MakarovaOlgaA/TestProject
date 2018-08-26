ko.validation.rules['minimalValue'] = {
    validator: function (val, min) {
        return val == undefined  || val === '' || val >= min;
    },
    message: 'Minimum value is {0}.'
};

ko.validation.rules['maximalValue'] = {
    validator: function (val, max) {
        return val == undefined || val === '' || val <= max;
    },
    message: 'Maximum value is {0}.'
};

ko.validation.rules['pastDate'] = {
    validator: function (val, minDate) {
        return val == undefined || val === '' || (val >= minDate && val <= new Date())
    },
    message: function (minDate) {
        return 'The date should be between ' + minDate.toLocaleDateString() + ' and today.'
    }
};

ko.validation.rules['integer'] = {
    validator: function (val, otherVal) {
        return val == undefined || val === '' || Number.isInteger(Number(val)) 
    },
    message: 'The value must be integer.'
};

ko.validation.registerExtenders();
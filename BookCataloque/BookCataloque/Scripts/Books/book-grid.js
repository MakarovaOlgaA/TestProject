var BookGrid = BookGrid || {};

(function () {
    var self = this;
    var dt = {};

    self.getBooksUrl = '';
    self.getBookUrl = '';
    self.deleteBookUrl = '';
    self.tblSelector = '';

    self.Initialize = function () {
        $(self.tblSelector).DataTable({
            "processing": true,
            "serverSide": true,
            "filter": true,
            "columns": [
                { name: "Title", data: "Title" },
                {
                    name: "PublicationDate", data: "PublicationDate",
                    render: function (date) {
                        return moment(date).format(GlobalSettings.DateFormat);
                    }
                },
                { name: "Rating", data: "Rating" },
                { name: "Pages", data: "Pages" },
                {
                    name: "Authors", data: "Authors",
                    render: function (authors) {
                        var resultMarkup = "";
                        var links = [];

                        for (var i = 0; i < authors.length; i++) {
                            var url = self.editAuthorUrl + "/" +authors[i].FirstName + "-" + authors[i].LastName;
                            links[i] = "<p><a class='btn btn-link' href='" + url + "'>" + authors[i].FirstName + " " + authors[i].LastName + "</a></p>";
                        }

                        return links.join("");
                    }
                },
                {
                    data: null,
                    render: function (data, type, row) {
                        return "<a class='btn btn-info' href='#' onclick=BookGrid.EditBook('" + row.BookID + "'); >Edit</a>" +
                            "<a href='#' class='btn btn-danger' onclick=BookGrid.DeleteBook('" + row.BookID + "'); >Delete</a>";
                    }
                },
            ],
            "ajax": {
                "url": self.getBooksUrl,
                "type": "POST",
                "datatype": "json",
                "data": function (d) {
                    return Object.assign(d, BookFilter.vm.ToJS())
                }
            }
        });
    };

    self.Reload = function () {
        $(self.tblSelector).DataTable().ajax.reload();
    };

    self.DeleteBook = function (bookID) {
        $.ajax({
            url: self.deleteBookUrl,
            type: "POST",
            data: JSON.stringify({ id: bookID }),
            contentType: 'application/json; charset=utf-8'
        }).done(function (result) {
            if (result.success) {
                self.Reload();
            }
        });
    }

    self.EditBook = function (bookID) {
        $.ajax({
            url: self.getBookUrl,
            type: "POST",
            data: JSON.stringify({ id: bookID }),
            contentType: 'application/json; charset=utf-8'
        }).done(function (result) {
            if (result.success) {
                BookEditor.OpenEditingModal(result.data);
            }
        });
    }
}).apply(BookGrid);
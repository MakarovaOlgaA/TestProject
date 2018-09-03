var BookGrid = BookGrid || {};

(function () {
    var self = this;
    var dt = {};

    self.getBooksUrl = '';
    self.deleteUrl = '';
    self.updateUrl = '';
    self.editAuthorUrl = '';
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
                        return "<a class='btn btn-info' href='#' onclick=BookGrid.DeleteBook('" + row.BookID + "'); >Edit</a>";
                    }
                },
                {
                    data: null,
                    render: function (data, type, row) {
                        return "<a href='#' class='btn btn-danger' onclick=BookEditor.DeleteBook('" + row.BookID + "'); >Delete</a>";
                    }
                }
            ],
            "ajax": {
                "url": self.getBooksUrl,
                "type": "POST",
                "datatype": "json",
                "data": function (d) {
                    var tmp = Object.assign(d, BookFilter.vm.toJS())
                    console.log(tmp);
                    return tmp;
                }
            }
        });
    };

    self.Reload = function () {
        $(self.tblSelector).DataTable().ajax.reload();
    };
}).apply(BookGrid);
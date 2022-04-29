app.directive('onlyDigits', function () {
    return {
        require: 'ngModel',
        restrict: 'A',
        link: function (scope, element, attr, ctrl) {
            function inputValue(val) {
                if (val) {
                    var digits = val.replace(/[^0-9]/g, '');

                    if (digits !== val) {
                        ctrl.$setViewValue(digits);
                        ctrl.$render();
                    }
                    return parseInt(digits, 10);
                }
                return undefined;
            }
            ctrl.$parsers.push(inputValue);
        }
    };
});

app.directive('validFile', function () {
    return {
        require: 'ngModel',
        link: function (scope, el, attrs, ctrl) {
            ctrl.$setValidity('validFile', el.val() != '');
            //change event is fired when file is selected
            el.bind('change', function () {
                ctrl.$setValidity('validFile', el.val() != '');
                scope.$apply(function () {
                    ctrl.$setViewValue(el.val());
                    ctrl.$render();
                });
            });
        }
    }
})

app.directive('accessibleForm', function () {
    return {
        restrict: 'A',
        link: function (scope, elem) {

            // set up event handler on the form element
            elem.on('submit', function () {

                // find the first invalid element
                var firstInvalid = elem[0].querySelector('.ng-invalid');

                // if we find one, we scroll with animation and then we set focus
                if (firstInvalid) {
                    angular.element('html:not(:animated),body:not(:animated)')
                        .animate({ scrollTop: angular.element(firstInvalid).parent().offset().top },
                            350,
                            'easeOutCubic',
                            function () {
                                firstInvalid.focus();
                            });
                }
            });
        }
    };
});

app.service('AddProductService', function ($http, $q) {
    var fac = {};
    fac.ProductData = function (d, file, file1, file2) {

        var formData = new FormData();
        formData.append("file", file);
        formData.append("file1", file1);
        formData.append("file2", file2);
        formData.append("ProductName", d.ProductName);
        formData.append("ProductQty", d.ProductQty);
        formData.append("CategoryID", d.CategoryID);
        formData.append("ProductPrice", d.ProductPrice);
        formData.append("Description", d.Description);        
        var defer = $q.defer();
        $http.post("/Data/AddNewProduct", formData,
            {
                withCredentials: true,
                headers: { 'Content-Type': undefined },
                transformRequest: angular.identity
            })
            .success(function (d) {
                defer.resolve(d);
            })
            .error(function () {
                defer.reject("File Upload Failed!");
            });

        return defer.promise;

    }
    return fac;
});


app.factory('StudentRegService', function ($http, $q) { // explained abour controller and service in part 2

    var fac = {};
    fac.PostCustomerData = function (d) {
        var formData = new FormData();

        //formData.append("file", file);



        //formData.append("file1", file1);
        //formData.append("file2", file2);

        //We can send more data to server using append     
        formData.append("FName", d.FName);
        formData.append("LName", d.LName);
        formData.append("Pass", d.Pass);
        formData.append("Address", d.Address);
        formData.append("PhoneNo", d.PhoneNo);       
        formData.append("Gender", d.Gender);
        formData.append("EmailAddress", d.EmailAddress);
        formData.append("DOB", d.DOB);

        var defer = $q.defer();
        $http.post("/Data/AddCustomer", formData,
            {
                withCredentials: true,
                headers: { 'Content-Type': undefined },
                transformRequest: angular.identity
            })
            .success(function (d) {
                defer.resolve(d);
            })
            .error(function () {
                defer.reject("File Upload Failed!");
            });

        return defer.promise;

    }
    return fac;

});

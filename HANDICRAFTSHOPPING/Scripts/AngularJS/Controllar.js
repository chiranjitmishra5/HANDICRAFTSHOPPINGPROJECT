/// <reference path="Controllar.js" />

app.controller('AddNewProductController', function ($scope, $http, AddProductService) {
    $http({
        method: 'GET',
        url: '/Data/GetCategoryList',
    }).then(function (response) {
        $scope.CategoryData = response.data;
    });
    $scope.Message = '';
    $scope.Submitted = false;
    $scope.IsFormValid = false;
    $scope.PData = {
        ProductName: '',
        ProductQty: '',
        CategoryID: '',
        ProductPrice: '',
        Description: ''
    };
    $scope.stateselected = false;
    $scope.ProfileImageupload = function (file) {
        $scope.ProfileImage = file[0];
    }
    $scope.ProfileImage1Upload = function (file) {
        $scope.ProfileImage1 = file[0];
    }

    $scope.ProfileImage2Upload = function (file) {
        $scope.ProfileImage2 = file[0];
    }

    $scope.$watch('f1.$valid', function (newVal) {

        $scope.IsFormValid = newVal;
    });
    $scope.AddProduct = function () {
        $scope.Submitted = true;
        if ($scope.IsFormValid) {
            showModal();
            AddProductService.ProductData($scope.PData, $scope.ProfileImage, $scope.ProfileImage1, $scope.ProfileImage2).then(function (d) {
                $('body').loadingModal('hide');
                $('body').loadingModal('destroy');
                if (d == true) {
                    alertify
                        .alert("Successfully Added the product.", function () {
                            window.location.href = "/Home/AddProduct";
                        }).setHeader('Product Add Status');
                }
                else {
                    alertify.error('Something Wrong Try Again')
                }

            });
        }
    };
});

app.controller('GetCategoryListController', function ($scope, $http) {
    $scope.CategorylList = []; //declare an empty array
    $scope.CategoryRecord = [];
    function GetData() {
        $http({
            method: 'GET',
            url: '/Data/GetAllCategory',
        }).then(function (response) {
            $scope.CategorylList = response.data.CategoryList;
        })
    }
    GetData();
    $scope.IsLogedIn = false;
    $scope.Message = '';
    $scope.Submitted = false;
    $scope.IsFormValid = false;
    $scope.CategoryData = {
        CategoryName: '',
    };    
    $scope.$watch('f1.$valid', function (newVal) {
        $scope.IsFormValid = newVal;
    });
    $scope.AddCategory = function () {
        $scope.Submitted = true;
        if ($scope.IsFormValid) {
            $http({
                contentType: "application/json; charset=utf-8",
                method: "POST",
                url: '/Data/AddCategory',
                dataType: "json",
                data: { "CategoryName": $scope.CategoryData.CategoryName },
                async: "isAsync"

            }).success(function (response) {
                if (response == true) {
                    alertify
                        .alert("Category Successfully Added", function () {
                            window.location.href = "/Home/AddCategory";
                        }).setHeader('Add Category Status');
                }
                else {
                    alertify.error('Something Wrong Try Again')
                }
            })
        }
    };  
    $scope.Delete = function (d) {       
        if (d >= 0) {
            alertify.confirm('Category Delete', 'Do You want To Delete This Category?', function () {
                $http({
                    contentType: "application/json; charset=utf-8",
                    method: "POST",
                    url: '/Data/DeleteCategory?ID=' + d,
                }).success(function (response) {
                    if (response == true) {
                        alertify
                            .alert("Category Successfully Deleted", function () {
                                window.location.href = "/Home/AddCategory";
                            }).setHeader('Delete Status');
                    }
                    else {
                        alertify.error('Something Wrong Try Again')
                    }
                })
            }
                , function () { });

        }
        else {
            alertify.error('Something Wrong Try Again')

        }

    }; 
    $scope.Edit = function (d) {
        $http({
            method: 'GET',
            url: '/Data/GetCategoryByID',
            params: { ID: d }
        }).then(function (response) {
            $scope.CategoryRecord = response.data;
        });
    }
    $scope.UpdateCategory = function (d, d1) {
        if (d != null && d != "" && d != undefined && d1 != null && d1 != "" && d1 != undefined) {
            $http({
                method: 'GET',
                url: '/Data/UpdateCategory',
                params: { ID: d, CategoryName: d1 }
            }).then(function (response) {
                if (response.data == true) {
                    GetData();                   
                    alertify.success('Successfully Updated')

                }
                else {
                    alertify.error('Something Wrong Try Again')
                }
            });

        }
        else {
            alertify.error('Class Name is Empty')
        }
    }

});

app.controller('GetAllProductListController', function ($scope, $http) {  
    $scope.ProductDetailsRecord = []; 
    $scope.ProductRecord = [];
    $http({
        method: 'GET',
        url: '/Data/GetCategoryList',
    }).then(function (response) {
        $scope.CategoryData = response.data;
    });

    $http({
        method: 'GET',
        url: '/Data/ProductDetails',    
    }).then(function (response) {
        $scope.ProductDetailsRecord = response.data;
        });
    $scope.Delete = function (d) {       
        if (d >= 0) {
            alertify.confirm('Product Delete', 'Do You want To Delete This Product?', function () {
                $http({
                    contentType: "application/json; charset=utf-8",
                    method: "POST",
                    url: '/Data/DeleteProduct?ID=' + d,
                }).success(function (response) {
                    if (response == true) {
                        alertify
                            .alert("Product Successfully Deleted", function () {
                                window.location.href = "/Home/UpdateProduct";
                            }).setHeader('Delete Status');
                    }
                    else {
                        alertify.error('Something Wrong Try Again')
                    }
                })
            }
                , function () { });

        }
        else {
            alertify.error('Something Wrong Try Again')

        }

    };
    
    $scope.Edit = function (d) {
        $http({
            method: 'GET',
            url: '/Data/GetProductID',
            params: { ID: d }
        }).then(function (response) {
            $scope.ProductRecord = response.data;
        });
    }

    $scope.UpdateCategory = function (d, d1) {
        if (d != null && d != "" && d != undefined && d1 != null && d1 != "" && d1 != undefined) {
            $http({
                method: 'GET',
                url: '/Data/UpdateCategory',
                params: { ID: d, CategoryName: d1 }
            }).then(function (response) {
                if (response.data == true) {
                    GetData();
                    alertify.success('Successfully Updated')

                }
                else {
                    alertify.error('Something Wrong Try Again')
                }
            });

        }
        else {
            alertify.error('Class Name is Empty')
        }
    }
});

app.controller('GetManuListController', function ($scope, $http) {
   
    $http({
        method: 'GET',
        url: '/Data/GetCategoryList',
    }).then(function (response) {      
        $scope.ManuData = response.data;
       
        })
    $scope.getCategoryID = function (d) {
        window.location.href = "/Home/CategoryProductDetails?e="+d;
    }


    $scope.IsLogedIn = false;
    $scope.Message = '';
    $scope.Submitted = false;
    $scope.IsFormValid = false;
    $scope.LoginData = {
        UserId: '',
        Password:''
    };
    $scope.$watch('f1.$valid', function (newVal) {
        $scope.IsFormValid = newVal;
       
    });


    //login
    $scope.Login = function () {
        $scope.Submitted = true;
        if ($scope.IsFormValid) {
            $http({
                contentType: "application/json; charset=utf-8",
                method: "POST",
                url: '/Data/LoginUser',
                dataType: "json",
                data: { "UserId": $scope.LoginData.UserId, "Password": $scope.LoginData.Password },
                async: "isAsync",
            }).then(function (response) {
              
                if (response.data.AccountID == 1) {
                    window.location.href = "/Home/AddCategory";

                }
                else {
                    window.location.href = "/Home/Index";
                }
            });
        }
    };
    //FPass

});

app.controller('DashBoardController', function ($scope, $http) {
    $http({
        method: 'GET',
        url: '/Data/DashBordView',
    }).then(function (response) {
        $scope.DashBoardData = response.data;
    })
});

app.controller('GetProductListController', function ($scope, $http,$location) {
    var paramValue = $location.search().e; 
    $scope.ProductRecord = [];
    $scope.CategoryID = paramValue;
    $http({
        method: 'GET',
        url: '/Data/ProductDetailsByID',
        params: { CategoryID: $scope.CategoryID }
    }).then(function (response) {
        $scope.ProductRecord = response.data;
    });
    $scope.getProductID = function (d) {
       
        window.location.href = "/Home/ProductDetails?p=" + d;
    }
});

app.controller('GetProductDetailsController', function ($scope, $http, $location) {   
    var paramValue = $location.search().p; 
    $scope.ProductDetailsRecord = [];
    $scope.ProductID = paramValue;
    $http({
        method: 'GET',
        url: '/Data/ProductDetailsByProductID',
        params: { ProductID: $scope.ProductID }
    }).then(function (response) {
        $scope.ProductDetailsRecord = response.data;
    });

    $scope.getProductIDandCustID = function (d,d1) {
        alert(d)
        window.location.href = "/Home/BYProduct?R=" + d + "&T="+d1;
    }

});

app.controller('StudentRegController', function ($scope, $http, StudentRegService) {

    $http({
        method: 'GET',
        url: '/Data/GetStudentRegData',

    }).then(function (response) {
        $scope.StdRegData = response.data;
    });

    $scope.emailFormat = /^[a-z]+[a-z0-9._]+@[a-z]+\.[a-z.]{2,5}$/;
    $scope.IsLogedIn = false;
    $scope.Message = '';
    $scope.Submitted = false;
    $scope.IsFormValid = false;
    $scope.StdData = {

        FName: '',
        LName: '',
        Pass: '',
        Address: '',
        PhoneNo: '',
        Gender: '',
        EmailAddress: '',
        DOB: '',
    };
    //$scope.stateselected = false;
    //0
    //$scope.ProfileImageupload = function (file) {
    //    $scope.ProfileImage = file[0];
    //}
    ////1


    //////2
    ////$scope.AdharImageUpload = function (file) {
    ////    $scope.AdharImage = file[0];
    ////    alert(file)
    ////}
    //////3
    ////$scope.VoterImageUpload = function (file) {
    ////    alert(file)
    ////    $scope.VoterImage = file[0];
    ////}
    //////4
    ////$scope.PANImageUpload = function (file) {
    ////    $scope.PANImage = file[0];
    ////}
    //////5
    ////$scope.DLImageUpload = function (file) {
    ////    $scope.DrivingLicenceImage = file[0];
    ////    alert($scope.DrivingLicenceImage)
    ////}
    //////6
    ////$scope.PAImageUpload = function (file) {
    ////    $scope.PAImage = file[0];
    ////}
    ////2
    //$scope.POAImageUpload = function (file) {
    //    $scope.POAImage = file[0];
    //}
    ////3
    //$scope.POIImageUpload = function (file) {
    //    $scope.POIImage = file[0];
    //}

    $scope.$watch('f1.$valid', function (newVal) {

        $scope.IsFormValid = newVal;
    });
    $scope.StudentReg = function () {

        $scope.Submitted = true;
        if ($scope.IsFormValid) {

            showModal();
            StudentRegService.PostCustomerData($scope.StdData).then(function (d) {
                $('body').loadingModal('hide');
                $('body').loadingModal('destroy');
                if (d == true) {
                    alertify
                        .alert("Successfully Created. Customer Id is: " + d.Id + " for future reference", function () {
                            window.location.href = "/Home/CustomerRegister";
                        }).setHeader(' Customer Registration Status');

                }
                else {
                    alertify.error('Something Wrong Try Again')
                }
            });
        }
    };
});


app.controller('GetProductDetailsController1', function ($scope, $http, $location) {
    var paramValue = $location.search().R;
    var paramValue1 = $location.search().T;
    $scope.ProductDetailsRecord = [];
    $scope.CustomerDetailsRecord = [];
    $scope.ProductID = paramValue;
    $scope.CustID = paramValue1;
    $http({
        method: 'GET',
        url: '/Data/ProductDetailsByProductID1',
        params: { ProductID: $scope.ProductID, CustID: $scope.CustID}
    }).then(function (response) {
        $scope.ProductDetailsRecord = response.data.productDetails;
        $scope.CustomerDetailsRecord = response.data.CustomerDetails;
    });
    //$scope.getProductID = function (d,d1) {
    //    window.location.href = "/Home/BYProduct?R=" + d;
    //}
});

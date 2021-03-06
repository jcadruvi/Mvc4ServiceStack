﻿function StoreViewModel() {

    var self = this;

    self.city = null;
    self.id = null;
    self.name = null;
    self.number = null;
    self.orgLevelCombo = null;
    self.retailerIdCombo = null;
    self.state = null;
    self.storeGridData = null;
    self.subOrgLevelCombo = null;

    var getSelectedStoreId = function () {
        var dataItem;
        if (!self.storeGridData) {
            return null;
        }
        dataItem = self.storeGridData.dataItem(self.storeGridData.select());
        if (!dataItem) {
            return null;
        }
        return dataItem.Id;
    };

    self.onDeleteClick = function() {
        var id;
        
        id = getSelectedStoreId();
        
        $.ajax({
            success: function (result) {
                self.storeGridData.dataSource.read();
                self.city(null);
                self.retailerIdCombo.value(null);
                self.id("");
                self.name("");
                self.number("");
                self.state("");
                self.orgLevelCombo.value(null);
                self.subOrgLevelCombo.value(null);
            },
            type: 'DELETE',
            url: 'servicestack/store?id=' + id
        });
    };

    self.onStoreGridChanged = function() {
        var postData = {};
        
        postData.Id = getSelectedStoreId();

        $.ajax({
            data: postData,
            dataType: 'json',
            success: function(result) {
                self.city(result.City);
                self.id(result.Id);
                self.name(result.Name);
                self.number(result.Number);
                self.state(result.State);
                if (self.orgLevelCombo) {
                    self.orgLevelCombo.value(result.OrgLevelId);
                }
                if (self.retailerIdCombo) {
                    self.retailerIdCombo.value(result.RetailerId);
                }
                if (self.subOrgLevelCombo) {
                    self.subOrgLevelCombo.value(result.SubOrgLevelId);
                }
            },
            type: 'GET',
            url: 'servicestack/store'
        });
    };

    self.onStoreSuccess = function (result) {
        self.storeGridData.dataSource.read();
        self.storeGridData.select($('tr[data-uid=' + self.storeGridData.dataSource.get(result.Id).uid + ']'));
        $('tr[data-uid=' + self.storeGridData.dataSource.get(result.Id).uid + ']').addClass('k-state-selected')
    };

    self.setObservables = function() {
        self.city = ko.observable();
        self.id = ko.observable();
        self.name = ko.observable();
        self.number = ko.observable();
        self.state = ko.observable();
        ko.applyBindings(self);
    };
}
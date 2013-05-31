function StoreViewModel() {

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

    self.onStoreGridChanged = function() {
        if (!self.storeGridData) {
            return;
        }
        var dataItem = self.storeGridData.dataItem(self.storeGridData.select());
        if (!dataItem) {
            return;
        }
        self.city(dataItem.City);
        self.id(dataItem.Id);
        self.name(dataItem.Name);
        self.number(dataItem.Number);
        self.state(dataItem.State);
        if (self.orgLevelCombo) {
            self.orgLevelCombo.value(dataItem.OrgLevelId);
        }
        if (self.retailerIdCombo) {
            self.retailerIdCombo.value(dataItem.RetailerId);
        }
        if (self.subOrgLevelCombo) {
            self.subOrgLevelCombo.value(dataItem.SubOrgLevelId);
        }
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
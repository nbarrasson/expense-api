@description('Unique WebApp Name.')
param webAppName string = uniqueString(resourceGroup().id)

@description('SKU of App Service Plan.')
param sku string = 'S1'

@description('The runtime stack of web app.')
param linuxFxVersion string = 'DOTNETCORE|6.0'

param location string

var appServicePlanName = toLower('AppServicePlan-${webAppName}')
var webSiteName = toLower('wapp-${webAppName}')

resource appServicePlan 'Microsoft.Web/serverfarms@2020-06-01' = {
  name: appServicePlanName
  location: location
  properties: {
    reserved: true
  }
  sku: {
    name: sku
  }
  kind: 'linux'
}

resource appService 'Microsoft.Web/sites@2020-06-01' = {
  name: webSiteName
  location: location
  properties: {
    serverFarmId: appServicePlan.id
    siteConfig: {
      linuxFxVersion: linuxFxVersion
    }
  }
}

output webSiteName string = webSiteName

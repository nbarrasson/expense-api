@description('The email address of the publisher of the APIM resource.')
@minLength(1)
param publisherEmail string

@description('Company name of the publisher of the APIM resource.')
@minLength(1)
param publisherName string

@description('Location for Azure resources.')
param location string

var random = uniqueString(resourceGroup().id)
var apimName = toLower('apim-${random}')

resource apim 'Microsoft.ApiManagement/service@2020-12-01' = {
  name: apimName
  location: location
  sku:{
    capacity: 0
    name: 'Consumption'
  }
  properties:{
    publisherEmail: publisherEmail
    publisherName: publisherName
  }   
}

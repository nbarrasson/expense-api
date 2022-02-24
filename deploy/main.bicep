param location string = deployment().location
param rgname string
param publisherEmail string
param publisherName string
param serviceUrl string
targetScope='subscription'

resource rg 'Microsoft.Resources/resourceGroups@2021-04-01' = {
  name: rgname
  location: location
}

module appservice 'appservice.bicep' = {
  name: 'appservice'
  scope: rg
  params: {
    location: location
  }
}

module apim 'apim.bicep' = {
  name: 'apim'
  scope: rg
  params: { 
    publisherEmail: publisherEmail
    publisherName: publisherName
    serviceUrl: serviceUrl
    location: location
  }
}

output webSiteName string = appservice.outputs.webSiteName

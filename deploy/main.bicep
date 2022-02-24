param location string = deployment().location
param rgname string
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

output webSiteName string = appservice.outputs.webSiteName

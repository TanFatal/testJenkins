import React from 'react'
import { ArrayInput, Create, SimpleForm, SimpleFormIterator, TextInput } from 'react-admin'

const CategoryCreate = () => {
  return (
    <Create>
      <SimpleForm>
        <TextInput source='name' />
        <TextInput source='code' />
        <TextInput source='description' />
        <ArrayInput source='categoryTypes'>
          <SimpleFormIterator inline>
            <TextInput source='name' />
            <TextInput source='code' />
            <TextInput source='description' />
          </SimpleFormIterator>
        </ArrayInput>
      </SimpleForm>
    </Create>
  )
}

export default CategoryCreate

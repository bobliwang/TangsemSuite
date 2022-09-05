
import { Swagger, TypeInfo, PropertyInfo } from '../models/swagger-models';

export function genEnum(enumDesc: string): string {
    const fullEnumMembers = enumDesc.split(',').map(x => x.trim()).filter(x => !!x);
    console.log(fullEnumMembers);

    const type = fullEnumMembers[0].substring(0, fullEnumMembers[0].lastIndexOf('.'));

    return `export enum ${type} {
      ${fullEnumMembers.map(m => {
            return `
        ${m.substring(m.indexOf('.') + 1)}`;
        }).join(',')}
  }`;
}

export function genType(typeInfo: TypeInfo): string {
    return `
  export interface ${typeInfo.name} {
    ${Object.keys(typeInfo.properties).map(key => {
            typeInfo.properties[key].name = key;

            return `
      ${genProperty(typeInfo.properties[key])}`;
        })}
  }  
    `;
}

export function genProperty(prop: PropertyInfo): string {
    if (prop.enum && prop.enum.length) {
        return `${prop.name}?: ${upperCaseFirst(prop.name)}`;
    }

    if (prop.$ref) {
        return `${prop.name}?: ${getTypeNameFromRef(prop.$ref)}`;
    }

    return `${prop.name}?: ${mapToTsType(prop.type)}`;
}

export function upperCaseFirst(text: string): string {
    return text[0].toUpperCase() + text.substring(1);
}

export function getTypeNameFromRef($ref: string): string {
    return $ref.substring($ref.lastIndexOf('/') + 1);
}

export function getEnumDescriptions(swagger: Swagger): string[] {
    const enums = [];

    Object.keys(swagger.definitions).forEach(typeName => {
        const typeDef = swagger.definitions[typeName];
        typeDef.name = typeName;

        Object.keys(typeDef.properties).forEach(propertyName => {
            const propDef = typeDef.properties[propertyName];
            propDef.name = propertyName;

            if (propDef.enum && propDef.enum.length) {
                if (enums.indexOf(propDef.description) < 0) {
                    enums.push(propDef.description);
                }
            }
        });
    });

    return enums;
}

export function mapToTsType(type: string): string {
    switch (type) {
        case 'integer':
            return 'number';
        default:
            return type;
    }
}

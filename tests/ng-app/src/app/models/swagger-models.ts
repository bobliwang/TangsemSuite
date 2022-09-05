
// Generated by https://quicktype.io
//
// To change quicktype's target language, run command:
//
//   "Set quicktype target language"

export enum Type {
    Boolean = 'boolean',
    Integer = 'integer',
    Number = 'number',
    String = 'string',
}

export enum Format {
    DateTime = 'date-time',
    Double = 'double',
    Int32 = 'int32',
    UUID = 'uuid',
}

export interface ApiInfo {
    version: string;
    title:   string;
}

export interface Swagger {
    /**
     * The swager version
     */
    swagger:     string;

    info:        ApiInfo;
    
    paths: {
        [name: string]: PathInfo
    };
    
    definitions: {
        [name: string]: TypeInfo;
    };
}



export interface PathInfo {
    [name: string]: MethodInfo;
}

export interface MethodInfo {

    /**
     * get, put, post ...
     */
    name?: string;

    operationId: string;

    tags: string[];

    /**
     * applicaiton/json and other media types.
     */
    consumes: Consume[];

    /**
     * applicaiton/json and other media types.
     */
    produces: string[];

    parameters: Parameter[];

    responses: { [status: string ]: ResponseInfo };
}

export interface SchemaInfo {
    $ref: string;
}

export interface Parameter {
    name: string;
    in: In;
    required: boolean;
    type?: string;
    schema?: SchemaInfo;
}

export interface ResponseInfo {
    description: string;
    schema: SchemaInfo;
}

export interface Definitions {
    [name: string]: TypeInfo;
}

export interface TypeInfo {
    type: Type;
    name?: string;
    properties: { [name: string]: PropertyInfo };
}

export interface PropertyInfo {
    type: Type;
    name?: string;
    format?: Format;
    description?: string;

    $ref: string;

    /**
     * Then it is a enum.
     */
    enum?: number[];
}

export enum Consume {
    ApplicationJSON = 'application/json',
    ApplicationJSONPatchJSON = 'application/json-patch+json',
    ConsumeApplicationJSON = 'application/*+json',
    TextJSON = 'text/json',
}

export enum In {
    Body = 'body',
    Path = 'path',
    Query = 'query',
}

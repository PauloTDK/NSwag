//-----------------------------------------------------------------------
// <copyright file="RapiDocSettings.cs" company="NSwag">
//     Copyright (c) Rico Suter. All rights reserved.
// </copyright>
// <license>https://github.com/RicoSuter/NSwag/blob/master/LICENSE.md</license>
// <author>Rico Suter, mail@rsuter.com</author>
//-----------------------------------------------------------------------

using NSwag.Generation;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System;
#if AspNetOwin
using Microsoft.Owin;

namespace NSwag.AspNet.Owin
#else
using Microsoft.AspNetCore.Http;

namespace NSwag.AspNetCore
#endif
{
    /// <summary>The settings for UseReDoc.</summary>
#if AspNetOwin
    public class RapiDocSettings<T> : SwaggerUiSettingsBase<T>
        where T : OpenApiDocumentGeneratorSettings, new()
#else
    public class RapiDocSettings : SwaggerUiSettingsBase
#endif
    {
        public RapiDocSettings()
        {
            UpdateRoute = true;
            SortTags = false;
            SortEndPointsBy = RapiDocSortEndpointsBy.Path;
            FillRequestFieldsWithExample = true;
            PersistAuth = false;
            Theme = RapiDocTheme.Dark;
            RegularFont = "'Open Sans', Avenir, 'Segoe UI', Arial, sans-serif";
            MonoFont = "Monaco, 'Andale Mono', 'Roboto Mono', 'Consolas' monospace";
            FontSize = RapiDocFontSize.Default;
            ShowMethodInNavBar = "false";
            UsePathInNavBar = false;
            NavActiveItemMarker = "left-bar";
            NavItemSpacing = RapiDocNavItemSpacing.Default;
            OnNavTagClick = "expand-collapse";
            Layout = RapiDocLayout.Row;
            RenderStyle = RapiDocRenderStyle.Read;
            ResponseAreaHeight = "300px";
            ShowInfo = true;
            InfoDescriptionHeadingsInNavbar = false;
            ShowComponents = false;
            ShowHeader = true;
            AllowAuthentication = true;
            AllowSpecUrlLoad = false;
            AllowSpecFileLoad = false;
            AllowSpecFileDownload = true;
            AllowSearch = true;
            AllowAdvancedSearch = true;
            AllowTry = true;
            ShowCurlBeforeTry = false;
            AllowServerSelection = false;
            AllowSchemaDescriptionExpandToggle = true;            
            SchemaStyle = RapidocSchemaStyle.Tree;
            SchemaExpandLevel = "999";
            SchemaDescriptionExpanded = false;
            SchemaHideReadOnly = RapiDocSchemaHideReadOnly.Default;
            SchemaHideWriteOnly = RapiDocSchemaHideWriteOnly.Default;
            DefaultSchemaTab = RapiDocDefaultSchemaTab.Model;

        }

        /// <summary>
        /// Gets or sets a title for the swagger-ui page
        /// </summary>
        public string DocumentTitle { get; set; } = "RapiDoc UI";

        /// <summary>Gets or sets the Swagger UI OAuth2 client settings.</summary>
        public OAuth2ClientSettings OAuth2Client { get; set; }

        /// <summary>
        /// Gets or sets additional content to place in the head of the Swagger UI page.
        /// </summary>
        public string CustomHeadContent { get; set; } = "";

        /// <summary>
        /// Update the url on browser's location whenever a new section is visited either by scrolling or clicking
        /// </summary>
        public bool UpdateRoute
        {
            get => (bool)(AdditionalSettings.TryGetValue("update-route", out var result) ? result : true);
            set => AdditionalSettings["update-route"] = value;
        }

        /// <summary>
        /// Add a custom prefix to each operation/api
        /// </summary>
        public string RoutePrefix
        {
            get => (string)(AdditionalSettings.TryGetValue("route-prefix", out var result) ? result : default);
            set => AdditionalSettings["route-prefix"] = value;
        }

        /// <summary>
        /// To list tags in alphabetic order
        /// </summary>
        public bool SortTags
        {
            get => (bool)(AdditionalSettings.TryGetValue("sort-tags", out var result) ? result : true);
            set => AdditionalSettings["sort-tags"] = value;
        }

        /// <summary>
        /// Sort endpoints within each tag
        /// </summary>
        public RapiDocSortEndpointsBy SortEndPointsBy
        {
            get => (RapiDocSortEndpointsBy)(AdditionalSettings.TryGetValue("sort-endpoints-by", out var result) ? Enum.Parse(typeof(RapiDocSortEndpointsBy), (string)result, true) : RapiDocSortEndpointsBy.Path);
            set => AdditionalSettings["sort-endpoints-by"] = Enum.GetName(typeof(RapiDocSortEndpointsBy), value).ToLower();
        }

        /// <summary>
        /// Heading text on top-left corner
        /// </summary>
        public string HeadingText
        {
            get => (string)(AdditionalSettings.TryGetValue("heading-text", out var result) ? result : default);
            set => AdditionalSettings["heading-text"] = value;
        }

        /// <summary>
        /// Initial location on the document (identified by method and path) where you want to go after the spec is loaded
        /// </summary>
        public string GotoPath
        {
            get => (string)(AdditionalSettings.TryGetValue("goto-path", out var result) ? result : default);
            set => AdditionalSettings["goto-path"] = value;
        }

        /// <summary>
        /// Request fields will be filled with example value (if provided in spec)
        /// </summary>
        public bool FillRequestFieldsWithExample
        {
            get => (bool)(AdditionalSettings.TryGetValue("fill-request-fields-with-example", out var result) ? result : true);
            set => AdditionalSettings["fill-request-fields-with-example"] = value;
        }

        /// <summary>
        /// Authentication will be persisted to localStorage
        /// </summary>
        public bool PersistAuth
        {
            get => (bool)(AdditionalSettings.TryGetValue("persist-auth", out var result) ? result : false);
            set => AdditionalSettings["persist-auth"] = value;
        }

        /// <summary>
        /// Is the base theme, which is used for calculating colors for various UI components
        /// </summary>
        public RapiDocTheme Theme 
        {
            get => (RapiDocTheme)(AdditionalSettings.TryGetValue("theme", out var result) ? Enum.Parse(typeof(RapiDocTheme), (string)result, true) : RapiDocTheme.Light);
            set => AdditionalSettings["theme"] = Enum.GetName(typeof(RapiDocTheme), value).ToLower();
        }


        /// <summary>
        /// Hex color code for main background
        /// </summary>
        public string BgColor
        {
            get => (string)(AdditionalSettings.TryGetValue("bg-color", out var result) ? result : default);
            set => AdditionalSettings["bg-color"] = value;
        }

        /// <summary>
        /// Hex color code for text
        /// </summary>
        public string TextColor
        {
            get => (string)(AdditionalSettings.TryGetValue("text-color", out var result) ? result : default);
            set => AdditionalSettings["text-color"] = value;
        }

        /// <summary>
        /// Hex color code for the header's background
        /// </summary>
        public string HeaderColor
        {
            get => (string)(AdditionalSettings.TryGetValue("header-color", out var result) ? result : default);
            set => AdditionalSettings["header-color"] = value;
        }

        /// <summary>
        /// Hex color code on various controls such as buttons, tabs
        /// </summary>
        public string PrimaryColor
        {
            get => (string)(AdditionalSettings.TryGetValue("primary-color", out var result) ? result : default);
            set => AdditionalSettings["primary-color"] = value;
        }

        /// <summary>
        /// RapiDoc will attempt to load fonts from CDN, if this is not intended, then set this to false.
        /// </summary>
        public bool LoadFonts
        {
            get => (bool)(AdditionalSettings.TryGetValue("load-fonts", out var result) ? result : true);
            set => AdditionalSettings["load-fonts"] = value;
        }

        /// <summary>
        /// Font name(s) to be used for regular text
        /// </summary>
        public string RegularFont
        {
            get => (string)(AdditionalSettings.TryGetValue("regular-font", out var result) ? result : default);
            set => AdditionalSettings["regular-font"] = value;
        }

        /// <summary>
        /// Font name(s) to be used for mono-spaced text
        /// </summary>
        public string MonoFont
        {
            get => (string)(AdditionalSettings.TryGetValue("regular-font", out var result) ? result : default);
            set => AdditionalSettings["regular-font"] = value;
        }

        /// <summary>
        ///  Sets the relative font sizes for the entire document
        /// </summary>
        public RapiDocFontSize FontSize
        {
            get => (RapiDocFontSize)(AdditionalSettings.TryGetValue("font-size", out var result) ? Enum.Parse(typeof(RapiDocFontSize), (string)result, true) : RapiDocFontSize.Default);
            set => AdditionalSettings["font-size"] = Enum.GetName(typeof(RapiDocFontSize), value).ToLower();
        }

        /// <summary>
        /// Allowed: false | as-plain-text | as-colored-text | as-colored-block
        /// Shows API Method names in the navigation bar (if you customized nav-background make sure there is a proper contrast)
        /// </summary>
        public string ShowMethodInNavBar
        {
            get => (string)(AdditionalSettings.TryGetValue("show-method-in-nav-bar", out var result) ? result : default);
            set => AdditionalSettings["show-method-in-nav-bar"] = value;
        }

        /// <summary>
        /// Set true to show API paths in the navigation bar instead of summary/description
        /// </summary>
        public bool UsePathInNavBar
        {
            get => (bool)(AdditionalSettings.TryGetValue("use-path-in-nav-bar", out var result) ? result : false);
            set => AdditionalSettings["use-path-in-nav-bar"] = value;
        }

        /// <summary>
        /// Navigation bar's background color
        /// </summary>
        public string NavBgColor
        {
            get => (string)(AdditionalSettings.TryGetValue("nav-bg-color", out var result) ? result : default);
            set => AdditionalSettings["nav-bg-color"] = value;
        }

        /// <summary>
        /// Navigation bar's Text color
        /// </summary>
        public string NavTextColor
        {
            get => (string)(AdditionalSettings.TryGetValue("nav-hover-text-color", out var result) ? result : default);
            set => AdditionalSettings["nav-hover-text-color"] = value;
        }

        /// <summary>
        /// Background color of the navigation item on mouse-over
        /// </summary>
        public string NavHoverBgColor
        {
            get => (string)(AdditionalSettings.TryGetValue("nav-hover-bg-color", out var result) ? result : default);
            set => AdditionalSettings["nav-hover-bg-color"] = value;
        }

        /// <summary>
        /// Text color of the navigation item on mouse-over
        /// </summary>
        public string NavHoverTextColor
        {
            get => (string)(AdditionalSettings.TryGetValue("show-method-in-nav-bar", out var result) ? result : default);
            set => AdditionalSettings["show-method-in-nav-bar"] = value;
        }

        /// <summary>
        /// Accent color used in navigtion Bar (such as background of active navigation item)
        /// </summary>
        public string NavAccentColor
        {
            get => (string)(AdditionalSettings.TryGetValue("nav-accent-color", out var result) ? result : default);
            set => AdditionalSettings["nav-accent-color"] = value;
        }

        /// <summary>
        /// Text color used in navigtion bar selected items
        /// </summary>
        public string NavAccentTextColor
        {
            get => (string)(AdditionalSettings.TryGetValue("nav-accent-text-color", out var result) ? result : default);
            set => AdditionalSettings["nav-accent-text-color"] = value;
        }

        /// <summary>
        /// Navigation active item indicator styles
        /// </summary>
        public string NavActiveItemMarker
        {
            get => (string)(AdditionalSettings.TryGetValue("nav-active-item-marker", out var result) ? result : default);
            set => AdditionalSettings["nav-active-item-marker"] = value;
        }

        /// <summary>
        /// Controls navigation item spacing
        /// </summary>
        public RapiDocNavItemSpacing NavItemSpacing
        {
            get => (RapiDocNavItemSpacing)(AdditionalSettings.TryGetValue("nav-item-spacing", out var result) ? Enum.Parse(typeof(RapiDocNavItemSpacing), (string)result, true) : RapiDocNavItemSpacing.Default);
            set => AdditionalSettings["nav-item-spacing"] = Enum.GetName(typeof(RapiDocNavItemSpacing), value).ToLower();
        }

        /// <summary>
        /// Allowed: expand-collapse | show-description
        /// Applies only to focused render-style. It determinses the behavior of clicking on a Tag in navigation bar.
        /// It can either expand-collapse the tag or take you to the tag's description page.
        /// </summary>
        public string OnNavTagClick
        {
            get => (string)(AdditionalSettings.TryGetValue("on-nav-tag-click", out var result) ? result : default);
            set => AdditionalSettings["on-nav-tag-click"] = value;
        }

        /// <summary>
        /// Layout helps in placement of request/response sections. In column layout, request response sections are placed one below the other,
        /// In row layout they are placed side by side.
        /// This attribute is applicable only when the device width is more than 768px and the render-style  is 'view'.
        /// </summary>
        public RapiDocLayout Layout
        {
            get => (RapiDocLayout)(AdditionalSettings.TryGetValue("layout", out var result) ? Enum.Parse(typeof(RapiDocLayout), (string)result, true) : RapiDocLayout.Row);
            set => AdditionalSettings["layout"] = Enum.GetName(typeof(RapiDocLayout), value).ToLower();
        }

        /// <summary>
        /// Determines display of api-docs.
        /// </summary>
        public RapiDocRenderStyle RenderStyle
        {
            get => (RapiDocRenderStyle)(AdditionalSettings.TryGetValue("render-style", out var result) ? Enum.Parse(typeof(RapiDocRenderStyle), (string)result, true) : RapiDocRenderStyle.Read);
            set => AdditionalSettings["render-style"] = Enum.GetName(typeof(RapiDocRenderStyle), value).ToLower();
        }

        /// <summary>
        /// Allowed: valid css height value such as 400px, 50%, 60vh etc
        /// Use this value to control the height of response textarea
        /// </summary>
        public string ResponseAreaHeight
        {
            get => (string)(AdditionalSettings.TryGetValue("response-area-height", out var result) ? result : default);
            set => AdditionalSettings["response-area-height"] = value;
        }

        /// <summary>
        /// Show/hide the documents info section
        /// Info section contains information about the spec, such as the title and description of the spec, the version, terms of services etc.
        /// In certain situation you may not need to show this section. For instance you are embedding this element inside a another help document.
        /// Chances are, the help doc may already have this info, in that case you may want to hide this section.
        /// </summary>
        public bool ShowInfo
        {
            get => (bool)(AdditionalSettings.TryGetValue("show-info", out var result) ? result : false);
            set => AdditionalSettings["show-info"] = value;
        }

        /// <summary>
        /// Include headers from info -> description section to the Navigation bar (applies to read mode only)
        /// Will get the headers from the markdown in info - description (h1 and h2) into the menu on the left (in read mode) along with links to them.
        /// This option allows users to add navigation bar items using Markdown
        /// </summary>
        public bool InfoDescriptionHeadingsInNavbar
        {
            get => (bool)(AdditionalSettings.TryGetValue("info-description-headings-in-navbar", out var result) ? result : false);
            set => AdditionalSettings["info-description-headings-in-navbar"] = value;
        }

        /// <summary>
        /// Show/hide the components section both in document and menu (available only in focused render-style)
        /// Will show the components section containing schemas, responses, examples, requestBodies, headers, securitySchemes, links and callbacks
        /// </summary>
        public bool ShowComponents
        {
            get => (bool)(AdditionalSettings.TryGetValue("show-components", out var result) ? result : false);
            set => AdditionalSettings["show-components"] = value;
        }

        /// <summary>
        /// Show/hide the header.
        /// If you do not want your user to open any other api spec, other than the current one, then set this attribute to false
        /// </summary>
        public bool ShowHeader
        {
            get => (bool)(AdditionalSettings.TryGetValue("show-header", out var result) ? result : false);
            set => AdditionalSettings["show-header"] = value;
        }

        /// <summary>
        /// Authentication feature, allows the user to select one of the authentication mechanism thats available in the spec.
        /// It can be http-basic, http-bearer or api-key.
        /// If you do not want your users to go through the authentication process, instead want them to use a pre-generated api-key
        /// then you may hide authentication section by setting this attribute to false
        /// and provide the api-key details using various api-key-???? attributes.
        /// </summary>
        public bool AllowAuthentication
        {
            get => (bool)(AdditionalSettings.TryGetValue("allow-authentication", out var result) ? result : false);
            set => AdditionalSettings["allow-authentication"] = value;
        }

        /// <summary>
        /// If set to 'false', user will not be able to load any spec url from the UI.
        /// </summary>
        public bool AllowSpecUrlLoad
        {
            get => (bool)(AdditionalSettings.TryGetValue("allow-spec-url-load", out var result) ? result : false);
            set => AdditionalSettings["allow-spec-url-load"] = value;
        }

        /// <summary>
        /// If set to 'false', user will not be able to load any spec file from the local drive.
        /// This attribute is applicable only when the device width is more than 768px, else this feature is not available
        /// </summary>
        public bool AllowSpecFileLoad
        {
            get => (bool)(AdditionalSettings.TryGetValue("allow-spec-file-load", out var result) ? result : false);
            set => AdditionalSettings["allow-spec-file-load"] = value;
        }

        /// <summary>
        /// If set to 'true', it provide buttons in the overview section to download the spec or open it in a new tab.
        /// </summary>
        public bool AllowSpecFileDownload
        {
            get => (bool)(AdditionalSettings.TryGetValue("allow-spec-file-download", out var result) ? result : false);
            set => AdditionalSettings["allow-spec-file-download"] = value;
        }

        /// <summary>
        /// Provides quick filtering of API
        /// </summary>
        public bool AllowSearch
        {
            get => (bool)(AdditionalSettings.TryGetValue("allow-search", out var result) ? result : false);
            set => AdditionalSettings["allow-search"] = value;
        }

        /// <summary>
        /// Provides advanced search functionality, to search through API-paths, API-description, API-parameters and API-Responses
        /// </summary>
        public bool AllowAdvancedSearch
        {
            get => (bool)(AdditionalSettings.TryGetValue("allow-advanced-search", out var result) ? result : false);
            set => AdditionalSettings["allow-advanced-search"] = value;
        }

        /// <summary>
        /// The 'TRY' feature allows you to make REST calls to the API server.
        /// To disable this feature, set it to false.
        /// </summary>
        public bool AllowTry
        {
            get => (bool)(AdditionalSettings.TryGetValue("allow-try", out var result) ? result : false);
            set => AdditionalSettings["allow-try"] = value;
        }

        /// <summary>
        /// If set to 'true', the cURL snippet is displayed between the request and the response without clicking on TRY
        /// </summary>
        public bool ShowCurlBeforeTry
        {
            get => (bool)(AdditionalSettings.TryGetValue("show-curl-before-try", out var result) ? result : false);
            set => AdditionalSettings["show-curl-before-try"] = value;
        }

        /// <summary>
        /// If set to 'false', user will not be able to see or select API server (Server List will be hidden, however users will be able to see the server url near the 'TRY' button, to know in advance where the TRY will send the request).
        /// The URL specified in the server-url attribute will be used if set, else the first server in the API specification file will be used.
        /// </summary>
        public bool AllowServerSelection
        {
            get => (bool)(AdditionalSettings.TryGetValue("allow-server-selection", out var result) ? result : false);
            set => AdditionalSettings["allow-server-selection"] = value;
        }

        /// <summary>
        /// Allow or hide the ability to expand/collapse field descriptions in the schema
        /// </summary>
        public bool AllowSchemaDescriptionExpandToggle
        {
            get => (bool)(AdditionalSettings.TryGetValue("allow-schema-description-expand-toggle", out var result) ? result : false);
            set => AdditionalSettings["allow-schema-description-expand-toggle"] = value;
        }

        /// <summary>
        /// Two different ways to display object-schemas in the responses and request bodies
        /// </summary>
        public RapidocSchemaStyle SchemaStyle
        {
            get => (RapidocSchemaStyle)(AdditionalSettings.TryGetValue("schema-style", out var result) ? Enum.Parse(typeof(RapidocSchemaStyle), (string)result, true) : RapidocSchemaStyle.Tree);
            set => AdditionalSettings["schema-style"] = Enum.GetName(typeof(RapidocSchemaStyle), value).ToLower();
        }

        /// <summary>
        /// Schemas are expanded by default, use this attribute to control how many levels in the schema should be expanded
        /// </summary>
        public string SchemaExpandLevel
        {
            get => (string)(AdditionalSettings.TryGetValue("schema-expand-level", out var result) ? result : default);
            set => AdditionalSettings["schema-expand-level"] = value;
        }

        /// <summary>
        /// Constraint and descriptions information of fields in the schema are collapsed to show only the first line.
        /// Set it to true if you want them to fully expanded
        /// </summary>
        public bool SchemaDescriptionExpanded
        {
            get => (bool)(AdditionalSettings.TryGetValue("schema-description-expanded", out var result) ? result : false);
            set => AdditionalSettings["schema-description-expanded"] = value;
        }

        /// <summary>
        /// Default will show read-only schema attributes in Responses, and in Requests of Webhook / Callback
        /// If you do not want to hide read-only fields in schema then you may set it to 'never'
        /// Note:This do not effect example generation.
        /// </summary>
        public RapiDocSchemaHideReadOnly SchemaHideReadOnly
        {
            get => (RapiDocSchemaHideReadOnly)(AdditionalSettings.TryGetValue("schema-hide-read-only", out var result) ? Enum.Parse(typeof(RapiDocSchemaHideReadOnly), (string)result, true) : RapiDocSchemaHideReadOnly.Default);
            set => AdditionalSettings["schema-hide-read-only"] = Enum.GetName(typeof(RapiDocSchemaHideReadOnly), value).ToLower();
        }

        /// <summary>
        /// default will show write-only schema attributes in Requests, and in Responses of Webhook / Callback
        /// If you do not want to hide write-only fields in schema then you may set it to 'never'
        /// Note:This do not effect example generation.
        /// </summary>
        public RapiDocSchemaHideWriteOnly SchemaHideWriteOnly
        {
            get => (RapiDocSchemaHideWriteOnly)(AdditionalSettings.TryGetValue("schema-hide-write-only", out var result) ? Enum.Parse(typeof(RapiDocSchemaHideWriteOnly), (string)result, true) : RapiDocSchemaHideWriteOnly.Default);
            set => AdditionalSettings["schema-hide-write-only"] = Enum.GetName(typeof(RapiDocSchemaHideWriteOnly), value).ToLower();
        }

        /// <summary>
        /// The schemas are displayed in two tabs - Model and Example.
        /// This option allows you to pick the default tab that you would like to be active
        /// </summary>
        public RapiDocDefaultSchemaTab DefaultSchemaTab
        {
            get => (RapiDocDefaultSchemaTab)(AdditionalSettings.TryGetValue("default-schema-tab", out var result) ? Enum.Parse(typeof(RapiDocDefaultSchemaTab), (string)result, true) : RapiDocDefaultSchemaTab.Model);
            set => AdditionalSettings["default-schema-tab"] = Enum.GetName(typeof(RapiDocDefaultSchemaTab), value).ToLower();
        }

        /// <summary>
        /// OpenAPI spec has a provision for providing the server url. The UI will list all the server URLs provided in the spec.
        /// The user can then select one URL to which he or she intends to send API calls while trying out the apis.
        /// However, if you want to provide an API server of your own which is not listed in the spec, you can use this property to provide one.
        /// It is helpful in the cases where the same spec is shared between multiple environment say Dev and Test and each have their own API server.
        /// </summary>
        public string ServerUrl
        {
            get => (string)(AdditionalSettings.TryGetValue("server-url", out var result) ? result : default);
            set => AdditionalSettings["server-url"] = value;
        }

        /// <summary>
        /// If you have multiple api-server listed in the spec, use this attribute to select the default API server, where all the API calls will goto.
        /// This can be changed later from the UI
        /// </summary>
        public string DefaultApiServer
        {
            get => (string)(AdditionalSettings.TryGetValue("default-api-server", out var result) ? result : default);
            set => AdditionalSettings["default-api-server"] = value;
        }

        /// <summary>
        /// Name of the API key that will be send while trying out the APIs
        /// </summary>
        public string ApiKeyName
        {
            get => (string)(AdditionalSettings.TryGetValue("api-key-name", out var result) ? result : default);
            set => AdditionalSettings["api-key-name"] = value;
        }

        /// <summary>
        /// Allowed: header, query
        /// Determines how you want to send the api-key.
        /// </summary>
        public string ApiKeyLocation
        {
            get => (string)(AdditionalSettings.TryGetValue("api-key-location", out var result) ? result : default);
            set => AdditionalSettings["api-key-location"] = value;
        }

        /// <summary>
        /// Value of the API key that will be send while trying out the APIs. Use '-' if will be set alter on UI.
        /// This can also be provided/overwritten from UI.
        /// </summary>
        public string ApiKeyValue
        {
            get => (string)(AdditionalSettings.TryGetValue("api-key-value", out var result) ? result : default);
            set => AdditionalSettings["api-key-name"] = value;
        }

        /// <summary>
        /// Allowed: omit | same-origin | include
        /// enables passing credentials/cookies in cross domain calls, as defined in the 
        /// Fetch standard, in CORS requests that are sent by the browser
        /// </summary>
        public string FetchCredentials
        {
            get => (string)(AdditionalSettings.TryGetValue("fetch-credentials", out var result) ? result : default);
            set => AdditionalSettings["fetch-credentials"] = value;
        }


        /// <summary>Gets the additional RapiDoc settings.</summary>
        public IDictionary<string, object> AdditionalSettings { get; } = new Dictionary<string, object>();

#if AspNetOwin
        internal override string TransformHtml(string html, IOwinRequest request)
#else
        internal override string TransformHtml(string html, HttpRequest request)
#endif
        {
            html = html.Replace("{AdditionalAttributes}", JsonConvert.SerializeObject(AdditionalSettings));
            html = html.Replace("{CustomStyle}", GetCustomStyleHtml(request));
            html = html.Replace("{CustomScript}", GetCustomScriptHtml(request));
            html = html.Replace("{DocumentTitle}", DocumentTitle);
            html = html.Replace("{CustomHeadContent}", CustomHeadContent);
            return html;
        }
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public enum RapiDocSortEndpointsBy
    {
        Path,
        Method,
        Summary,
        None
    }

    public enum RapiDocTheme
    {
        Dark,
        Light
    }

    public enum RapiDocFontSize
    {
        Default,
        Large,
        Largest
    }

    public enum RapiDocNavItemSpacing
    {
        Default,
        Compact,
        Relaxed
    }

    public enum RapiDocLayout
    {
        Row,
        Column
    }

    public enum RapiDocRenderStyle
    {
        Read,
        View,
        Focused
    }

    public enum RapidocSchemaStyle
    {
        Tree,
        Table
    }

    public enum RapiDocSchemaHideReadOnly
    {
        Default,
        Never
    }

    public enum RapiDocSchemaHideWriteOnly
    {
        Default,
        Never
    }

    public enum RapiDocDefaultSchemaTab
    {
        Model,
        Schema
    }

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

}
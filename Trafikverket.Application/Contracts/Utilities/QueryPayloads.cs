using System;
using System.Collections.Generic;
using System.Text;

namespace Trafikverket.Application.Contracts.Utilities
{
    public static class QueryPayloads
    {
        public const string BaseStart = "<REQUEST> " +
                                          "<LOGIN authenticationkey = 'e4368402c0ab432582e58624af40c1ca' />";
        public const string BaseEnd = "</QUERY>" +
                                       "</REQUEST>";
        public static class Camera
        {
            public const string GetAllCamera = "<QUERY objecttype = 'Camera' schemaversion = '1' >";
            public const string GetAllCameraByDirection90 = "<QUERY objecttype = 'Camera' schemaversion = '1' limit = '100000' >" +
                                                             "<FILTER>" +
                                                             "<EQ name = 'Direction' value = '90' />" +
                                                             "</FILTER>";
        }
    }
}


;
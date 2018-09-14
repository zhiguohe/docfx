// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Newtonsoft.Json.Linq;
using Xunit;

namespace Microsoft.Docs.Build
{
    public class MustacheTemplateTest
    {
        private readonly MustacheTemplate _template = new MustacheTemplate("data/mustache");

        [Theory]
        [InlineData("test", "{'description':'hello'}", "<div>hello<div>a b</div></div>")]
        public void RenderMustacheTemplate(string name, string json, string html)
        {
            var model = JToken.Parse(json.Replace('\'', '"'));

            Assert.Equal(
                TestUtility.NormalizeHtml(html),
                TestUtility.NormalizeHtml(_template.Render(name, model)));
        }
    }
}

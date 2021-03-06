﻿// Copyright © 2015 - Present RealDimensions Software, LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
//
// You may obtain a copy of the License at
//
// 	http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace chocolatey.package.validator.tests.infrastructure.app
{
    using chocolatey.package.validator.infrastructure.app.rules;
    using chocolatey.package.validator.infrastructure.rules;
    using Moq;
    using NuGet;
    using Should;

    public abstract class DescriptionHeadingMarkdownRequirementSpecsBase : TinySpec
    {
        protected DescriptionHeadingMarkdownRequirement requirement;
        protected Mock<IPackage> package = new Mock<IPackage>();

        public override void Context()
        {
            requirement = new DescriptionHeadingMarkdownRequirement();
        }

        public class when_inspecting_package_with_valid_markdown_heading_in_description : DescriptionHeadingMarkdownRequirementSpecsBase
        {
            private PackageValidationOutput result;

            public override void Context()
            {
                base.Context();

                package.Setup(p => p.Description).Returns(@"# Heading 1

Stuff

## Heading 2

Stuff

### Heading 3

Stuff

#### Heading 4

Stuff

##### Heading 5

Stuff

###### Heading 6

Stuff");

            }

            public override void Because()
            {
                result = requirement.is_valid(package.Object);
            }

            [Fact]
            public void should_be_valid()
            {
                result.Validated.ShouldBeTrue();
            }

            [Fact]
            public void should_not_override_the_base_message()
            {
                result.ValidationFailureMessageOverride.ShouldBeNull();
            }
        }

        public class when_inspecting_package_with_no_description : DescriptionHeadingMarkdownRequirementSpecsBase
        {
            private PackageValidationOutput result;

            public override void Because()
            {
                result = requirement.is_valid(package.Object);
            }

            [Fact]
            public void should_be_valid()
            {
                result.Validated.ShouldBeTrue();
            }

            [Fact]
            public void should_not_override_the_base_message()
            {
                result.ValidationFailureMessageOverride.ShouldBeNull();
            }
        }

        public class when_inspecting_package_with_invalid_markdown_heading_1_in_description : DescriptionHeadingMarkdownRequirementSpecsBase
        {
            private PackageValidationOutput result;

            public override void Context()
            {
                base.Context();

                package.Setup(p => p.Description).Returns(@"#Heading 1

Stuff

## Heading 2

Stuff

### Heading 3

Stuff

#### Heading 4

Stuff

##### Heading 5

Stuff

###### Heading 6

Stuff");

            }

            public override void Because()
            {
                result = requirement.is_valid(package.Object);
            }

            [Fact]
            public void should_not_be_valid()
            {
                result.Validated.ShouldBeFalse();
            }

            [Fact]
            public void should_not_override_the_base_message()
            {
                result.ValidationFailureMessageOverride.ShouldBeNull();
            }

        }

        public class when_inspecting_package_with_invalid_markdown_heading_2_in_description : DescriptionHeadingMarkdownRequirementSpecsBase
        {
            private PackageValidationOutput result;

            public override void Context()
            {
                base.Context();

                package.Setup(p => p.Description).Returns(@"# Heading 1

Stuff

##Heading 2

Stuff

### Heading 3

Stuff

#### Heading 4

Stuff

##### Heading 5

Stuff

###### Heading 6

Stuff");

            }

            public override void Because()
            {
                result = requirement.is_valid(package.Object);
            }

            [Fact]
            public void should_not_be_valid()
            {
                result.Validated.ShouldBeFalse();
            }

            [Fact]
            public void should_not_override_the_base_message()
            {
                result.ValidationFailureMessageOverride.ShouldBeNull();
            }

        }

        public class when_inspecting_package_with_invalid_markdown_heading_3_in_description : DescriptionHeadingMarkdownRequirementSpecsBase
        {
            private PackageValidationOutput result;

            public override void Context()
            {
                base.Context();

                package.Setup(p => p.Description).Returns(@"# Heading 1

Stuff

## Heading 2

Stuff

###Heading 3

Stuff

#### Heading 4

Stuff

##### Heading 5

Stuff

###### Heading 6

Stuff");

            }

            public override void Because()
            {
                result = requirement.is_valid(package.Object);
            }

            [Fact]
            public void should_not_be_valid()
            {
                result.Validated.ShouldBeFalse();
            }

            [Fact]
            public void should_not_override_the_base_message()
            {
                result.ValidationFailureMessageOverride.ShouldBeNull();
            }

        }

        public class when_inspecting_package_with_invalid_markdown_heading_4_in_description : DescriptionHeadingMarkdownRequirementSpecsBase
        {
            private PackageValidationOutput result;

            public override void Context()
            {
                base.Context();

                package.Setup(p => p.Description).Returns(@"#Heading 1

Stuff

## Heading 2

Stuff

### Heading 3

Stuff

####Heading 4

Stuff

##### Heading 5

Stuff

###### Heading 6

Stuff");

            }

            public override void Because()
            {
                result = requirement.is_valid(package.Object);
            }

            [Fact]
            public void should_not_be_valid()
            {
                result.Validated.ShouldBeFalse();
            }

            [Fact]
            public void should_not_override_the_base_message()
            {
                result.ValidationFailureMessageOverride.ShouldBeNull();
            }

        }

        public class when_inspecting_package_with_invalid_markdown_heading_5_in_description : DescriptionHeadingMarkdownRequirementSpecsBase
        {
            private PackageValidationOutput result;

            public override void Context()
            {
                base.Context();

                package.Setup(p => p.Description).Returns(@"# Heading 1

Stuff

## Heading 2

Stuff

### Heading 3

Stuff

#### Heading 4

Stuff

#####Heading 5

Stuff

###### Heading 6

Stuff");

            }

            public override void Because()
            {
                result = requirement.is_valid(package.Object);
            }

            [Fact]
            public void should_not_be_valid()
            {
                result.Validated.ShouldBeFalse();
            }

            [Fact]
            public void should_not_override_the_base_message()
            {
                result.ValidationFailureMessageOverride.ShouldBeNull();
            }

        }

        public class when_inspecting_package_with_invalid_markdown_heading_6_in_description : DescriptionHeadingMarkdownRequirementSpecsBase
        {
            private PackageValidationOutput result;

            public override void Context()
            {
                base.Context();

                package.Setup(p => p.Description).Returns(@"# Heading 1

Stuff

## Heading 2

Stuff

### Heading 3

Stuff

#### Heading 4

Stuff

##### Heading 5

Stuff

######Heading 6

Stuff");

            }

            public override void Because()
            {
                result = requirement.is_valid(package.Object);
            }

            [Fact]
            public void should_not_be_valid()
            {
                result.Validated.ShouldBeFalse();
            }

            [Fact]
            public void should_not_override_the_base_message()
            {
                result.ValidationFailureMessageOverride.ShouldBeNull();
            }

        }
    }
}
